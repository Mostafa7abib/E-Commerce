using Services.Absraction;
using Services;

namespace E_Commerce.Extensions
{
    public static class CoreServicesExtension
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddAutoMapper(typeof(Services.AssemplyReference).Assembly);
            return services;
        }
    }
}
