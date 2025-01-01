﻿
using Estoque.Domain.Notifications;
using MediatR;

namespace Estoque.Presentation.Api.Middlewares
{
    public class DomainNotificationMiddleware : IMiddleware
    {
        private readonly DomainNotificationHandler _notifications;
        public DomainNotificationMiddleware(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next.Invoke(context);

            if (_notifications.HasNotNotification)
                return;

            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(new { Success = false, Errors = _notifications.Notifications });
        }
    }
}
