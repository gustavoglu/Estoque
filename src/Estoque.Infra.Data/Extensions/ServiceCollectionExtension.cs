using Estoque.Domain.Interfaces;
using Estoque.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Infra.Data.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfraData(this IServiceCollection services,
                                                IConfiguration configuration)
        {

            if (configuration is null)
                throw new NullReferenceException(nameof(IConfiguration));

            string? sqlServerConnectionString = configuration.GetConnectionString("SqlServer");
            if (string.IsNullOrEmpty(sqlServerConnectionString))
                throw new NullReferenceException(nameof(sqlServerConnectionString));

            services.AddDbContext<SQLContext>(opt => opt.UseSqlServer(sqlServerConnectionString));
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
        }
    }
}
