using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Modules.School.WebAPI.Filters;

/// <summary>
/// Runs FluentValidation for action parameters and adds errors to ModelState
/// so that ApiBehaviorOptions.InvalidModelStateResponseFactory is used for the response.
/// </summary>
/// <remarks>
/// Called by ASP.NET Core's action filter pipeline (not by our code).
/// Registered in Program.cs: options.Filters.Add&lt;FluentValidationActionFilter&gt;(order: -3000).
/// Pipeline: Request → Routing → Model binding → [this filter runs here] → Action (e.g. CreateSchool).
/// </remarks>
public class FluentValidationActionFilter : IAsyncActionFilter
{
    private readonly IServiceProvider _serviceProvider;

    public FluentValidationActionFilter(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>Invoked by the framework for each request that hits a controller action (see order -3000 in Program.cs).</summary>
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        foreach (var argument in context.ActionArguments.Values)
        {
            if (argument == null) continue;

            var type = argument.GetType();
            var validatorType = typeof(IValidator<>).MakeGenericType(type);
            var validator = _serviceProvider.GetService(validatorType);
            if (validator is not IValidator fluentValidator) continue;

            var contextType = typeof(FluentValidation.ValidationContext<>).MakeGenericType(type);
            var validationContext = (IValidationContext)Activator.CreateInstance(contextType, argument)!;
            var result = await fluentValidator.ValidateAsync(validationContext);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                    context.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }

        await next();
    }
}
