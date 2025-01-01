using Estoque.Domain.Notifications;
using FluentValidation;
using MediatR;

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
            var context = new ValidationContext<TRequest>(request);

            var validationFailures = await Task.WhenAll(
                _validators.Select(validator => validator.ValidateAsync(context)));

            var errors = validationFailures
                .Where(validationResult => !validationResult.IsValid)
                .SelectMany(validationResult => validationResult.Errors);

            if (errors.Any())
            {
                var notifications = errors.Select(validationFailure => 
                                                    new DomainNotification(validationFailure.PropertyName, validationFailure.ErrorMessage))
                                            .ToList();
                notifications.ForEach(error => _mediator.Publish(error));
                throw new ValidationException(errors);
            }

            var response = await next();

            return response;
        }
    }
}
