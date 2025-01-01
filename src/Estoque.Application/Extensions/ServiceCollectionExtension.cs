using Estoque.Application.Handlers;
using Estoque.Application.MapperProfiles;
using Estoque.Application.Pipelines;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Estoque.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(ProductHandler).Assembly)
                                        .AddOpenBehavior(typeof(ValidationBehavior<,>)));
            services.AddAutoMapper(typeof(RequestToEntityProfile).Assembly);

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
