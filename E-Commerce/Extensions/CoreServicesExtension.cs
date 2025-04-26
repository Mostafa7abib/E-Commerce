using Services.Absraction;
using Services;
using Shared;

namespace E_Commerce.Extensions
{
    public static class CoreServicesExtension
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddAutoMapper(typeof(Services.AssemplyReference).Assembly);
            services.Configure<JwtOptins>(configuration.GetSection("JwtOptins"));
            return services;
        }
    }
}
