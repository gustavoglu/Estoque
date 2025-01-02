
using Estoque.Domain.Notifications;
using Estoque.Presentation.Api.ViewModels;
using MediatR;

namespace Estoque.Presentation.Api.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly DomainNotificationHandler _notifications;
        public ExceptionMiddleware(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);

                if (_notifications.HasNotification)
                {

                    context.Response.StatusCode = StatusCodes.Status400BadRequest;

                    await context.Response
                        .WriteAsJsonAsync(ApiResult.ErrorResult(_notifications.Notifications.Select(err => $"{err.Type}, {err.Value}")));
                }
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response
                    .WriteAsJsonAsync(ApiResult.ErrorResult(ex.Message));
            }
        }
    }
}
