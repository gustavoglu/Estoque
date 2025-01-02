using Estoque.Domain.Notifications;
using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Estoque.Application.Pipelines
{
    public sealed class ValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly IMediator _mediator;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators,
            IMediator mediator)
        {
            _validators = validators;
            _mediator = mediator;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            //var context = new ValidationContext<TRequest>(request);

            //var validationFailures = await Task.WhenAll(
            //    _validators.Select(validator => validator.ValidateAsync(context)));

            //var errors = validationFailures
            //    .Where(validationResult => !validationResult.IsValid)
            //    .SelectMany(validationResult => validationResult.Errors);

            //if (errors.Any())
            //{
            //    var notifications = errors.Select(validationFailure => 
            //                                        new DomainNotification(validationFailure.PropertyName, validationFailure.ErrorMessage))
            //                                .ToList();
            //    notifications.ForEach(error => _mediator.Publish(error));
            //    throw new ValidationException(errors);
            //}

            //var response = await next();

            //return response;

            ArgumentNullException.ThrowIfNull(next);

            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(
                    _validators.Select(v =>
                        v.ValidateAsync(context, cancellationToken)))
                    .ConfigureAwait(false);

                var failures = validationResults
                    .Where(r => r.Errors.Count > 0)
                    .SelectMany(r => r.Errors)
                    .ToList();

                if (failures.Count > 0)
                {
                    foreach (var error in failures)
                    {
                        await _mediator.Publish(new DomainNotification(error.PropertyName, error.ErrorMessage))
                            .ConfigureAwait(false); ;
                    }

                    throw new FluentValidation.ValidationException(failures);
                }
            }
            return await next().ConfigureAwait(false);
        }
    }
}
