using Estoque.Domain.Notifications;
using Microsoft.Extensions.DependencyInjection;

namespace Estoque.Domain.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddDomain(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(DomainNotificationHandler).Assembly));
        }
    }
}
