using Domain.Contracts;
using Persistance.Data.DataSeeding;
using Persistance.Data;
using Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace E_Commerce.Extensions
{
    public static class InfrastructureServicesExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            { 
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IDbIntializer, DbIntializer>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            services.AddSingleton<IConnectionMultiplexer>(services=>
            ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis")!)
            );
            return services;
        }
    }
}
