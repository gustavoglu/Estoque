using Estoque.Domain.Notifications;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Estoque.Domain.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddDomain(this IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        }
    }
}
