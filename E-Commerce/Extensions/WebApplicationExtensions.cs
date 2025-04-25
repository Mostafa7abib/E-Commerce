using Domain.Contracts;
using Microsoft.AspNetCore.Diagnostics;

namespace E_Commerce.Extensions
{
    public static class WebApplicationExtensions
    {
        public static async Task<WebApplication> SeedByAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbIntializer = scope.ServiceProvider.GetRequiredService<IDbIntializer>();
            await dbIntializer.IntializeAsync();
            return app;
        }
        public static WebApplication UseCustomMiddleWare(this WebApplication app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            return app;
        }
    }
}
