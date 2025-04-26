using Domain.Contracts;
using E_Commerce.Extensions;
using E_Commerce.Factories;
using E_Commerce.MiddleWares;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance.Data;
using Persistance.Data.DataSeeding;
using Persistance.Repositories;
using Services;
using Services.Absraction;

namespace E_Commerce
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            #region Services
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            // Presentation Services
            builder.Services.AddPresentationServices();
            // Core Services
            builder.Services.AddCoreServices(builder.Configuration);
            // Infrastructure Services
            builder.Services.AddInfrastructureServices(builder.Configuration);
            #endregion

            #region MiddleWares
            var app = builder.Build();
            app.UseCustomMiddleWare();
            await app.SeedByAsync();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //Read All Data in wwwroot
            app.UseStaticFiles();

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run(); 
            #endregion
        }
    }
}
