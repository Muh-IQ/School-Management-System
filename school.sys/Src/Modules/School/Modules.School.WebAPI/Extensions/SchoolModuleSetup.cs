using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Modules.School.Application;
using Modules.School.Infrastructure;
using Modules.School.WebAPI.Controllers.V1;
using Modules.School.WebAPI.Extensions.Middleware;
using Modules.School.WebAPI.Filters;
using Modules.School.WebAPI.Validators;

namespace Modules.School.WebAPI.Extensions;

public static class SchoolModuleSetup
{
    public static IServiceCollection AddSchoolModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructureServices(configuration);
        services.AddApplicationServices();
        services.AddValidatorsFromAssemblyContaining<SchoolAddDTOValidator>();
        return services;
    }

    /// <summary>
    /// Adds School module and configures MVC (controllers, validation filter, validation response).
    /// Call from host: builder.Services.AddSchoolModule(builder.Configuration, builder.Services.AddControllers()).
    /// </summary>
    public static IMvcBuilder AddSchoolModule(this IMvcBuilder mvcBuilder, IConfiguration configuration)
    {
        var services = mvcBuilder.Services;
        services.AddSchoolModule(configuration);

        mvcBuilder.AddApplicationPart(typeof(SchoolController).Assembly);
        mvcBuilder.AddMvcOptions(options =>
            options.Filters.Add<FluentValidationActionFilter>(order: -3000));

        services.ConfigureFluentValidationResponse();
        services.AddScoped<FluentValidationActionFilter>();

        return mvcBuilder;
    }

    /// <summary>
    /// Registers the global exception handler middleware. Catches unhandled system errors
    /// and returns clean ApiResponse JSON instead of HTML/stack traces. Call early in the pipeline.
    /// </summary>
    public static IApplicationBuilder UseSchoolGlobalExceptionHandler(this IApplicationBuilder app)
    {
        return app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
    }
}
