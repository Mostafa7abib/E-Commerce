using System.Net;
using Microsoft.AspNetCore.Mvc;
using Shared.ErrorModels;

namespace E_Commerce.Factories
{
    public class ApiResponseFactory
    {
        public static IActionResult CustomValidationErrorResponse(ActionContext context)
        {
            // Context==> ModelState ==> Dictionary<string, ModelStateEntry>
            // Get All Errors in ModelState entry
            var errors = context.ModelState.Where(
                error => error.Value.Errors.Any()).
                Select(error=> new ValidationError
                {
                    Field = error.Key,
                    Errors = error.Value.Errors.Select(e => e.ErrorMessage)
                });
            var response = new ValidationErrorResponse
            {
                StatusCode =(int)HttpStatusCode.BadRequest,
                ErrorMessage = "Validation Field",
                Errors = errors
            };
            return new BadRequestObjectResult(response);
        }
    }
}
