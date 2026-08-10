using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Modules.User.WebAPI.Extensions
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

                var validatorType = typeof(IValidator<>)
                    .MakeGenericType(argumentType);// reflection to identifty the which dto  from request 

                // get validator from DI   services.AddValidatorsFromAssemblyContaining<CreateUserDtoValidator>();
                var validator = context.HttpContext.RequestServices
                    .GetService(validatorType) as IValidator;

                if (validator is null)
                    continue;

                var validationContext = new ValidationContext<object>(argument);


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
                        new ValidationProblemDetails(errors)
                    );

                    return;
                }
            }

            await next();
        }
    }
}
