using Estoque.Application.Extensions;
using Estoque.Domain.Extensions;
using Estoque.Infra.Data.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Estoque.Infra.Crosscutting.IoC
{
    public static class NativeInjection
    {
        public static void InjectServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDomain();
            services.AddInfraData(configuration);
            services.AddApplication();
        }
    }
}
