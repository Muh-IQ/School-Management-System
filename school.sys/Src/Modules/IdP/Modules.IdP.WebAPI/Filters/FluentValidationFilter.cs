using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Modules.IdP.WebAPI.Filters
{
    public class FluentValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            foreach (var argument in context.ActionArguments.Values)
            {
                if (argument is null)
                    continue;

                var argumentType = argument.GetType();

                // Build IValidator<T> dynamically
                var validatorType = typeof(IValidator<>)
                    .MakeGenericType(argumentType);

                // Get validator from DI
                var validator = context.HttpContext.RequestServices
                    .GetService(validatorType) as IValidator;

                // No validator exists for this argument
                if (validator is null)
                    continue;

                var validationContext =
                    new ValidationContext<object>(argument);


                var result = await validator.ValidateAsync(
                    validationContext,
                    context.HttpContext.RequestAborted);

                if (!result.IsValid)
                {
                    var errors = result.Errors
                        .GroupBy(x => x.PropertyName)
                        .ToDictionary(
                            x => x.Key,
                            x => x.Select(e => e.ErrorMessage).ToArray());

                    context.Result = new BadRequestObjectResult(
                        new ValidationProblemDetails(errors));

                    return;
                }
            }

            // Validation passed
            await next();
        }
    }
}
