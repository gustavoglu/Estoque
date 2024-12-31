using Estoque.Application.Handlers;
using Estoque.Application.MapperProfiles;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(ProductHandler).Assembly));
            services.AddAutoMapper(typeof(RequestToEntityProfile).Assembly);
        }
    }
}
