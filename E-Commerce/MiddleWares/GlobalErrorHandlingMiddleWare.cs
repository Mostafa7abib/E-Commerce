using System.Net;
using Domain.Exceptions;
using Shared.ErrorModels;

namespace E_Commerce.MiddleWares
{
    public class GlobalErrorHandlingMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalErrorHandlingMiddleWare> _logger;

        public GlobalErrorHandlingMiddleWare(RequestDelegate next , ILogger<GlobalErrorHandlingMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
                if(context.Response.StatusCode == (int) HttpStatusCode.NotFound)
                {
                    await HandleNotFoundApiAsync(context);
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError($"An Error Ocurred {ex}");
                // Handle the exception
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleNotFoundApiAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            var response = new ErrorDetails()
            {
                StatusCode = (int)HttpStatusCode.NotFound,
                ErrorMessage = $"The End Point {context.Request.Path} Not Found"
            }.ToString();
            await context.Response.WriteAsync(response);
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            // Set Content Type [application/json]
            context.Response.ContentType = "application/json";
            // Set Status Code [500]
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.StatusCode = ex switch
            {
                NotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int)HttpStatusCode.InternalServerError
            };
            // Return Standard Response
            var response = new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                ErrorMessage = ex.Message
            }.ToString();
            await context.Response.WriteAsync(response);
        }
    }
}
