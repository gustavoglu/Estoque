using Estoque.Domain.Notifications;
using Estoque.Presentation.Api.ViewModels;
using MediatR;

namespace Estoque.Presentation.Api.Helpers
{
    public static class EndpointHelper
    {
        public static IResult ResponseDefault(INotificationHandler<DomainNotification> notifications, object? data = null)
        {
            var domainNotificationHandler = (DomainNotificationHandler)notifications;
            if (domainNotificationHandler.HasNotification)
            {
                string[] errors = domainNotificationHandler.Notifications
                                                            .Select(notification => $"{notification.Value}")
                                                            .ToArray();

                return Results.BadRequest(ApiResult.ErrorResult(data, errors));
            }

            return Results.Ok(ApiResult.SuccessResult(data));
        }
    }
}
