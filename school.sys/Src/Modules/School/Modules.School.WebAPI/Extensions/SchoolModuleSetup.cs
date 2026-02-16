using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Modules.School.Application;
using Modules.School.Infrastructure;
using Modules.School.WebAPI.Middleware;

namespace Modules.School.WebAPI.Extensions;

public static class SchoolModuleSetup
{
    public static IServiceCollection AddSchoolModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructureServices(configuration);
        services.AddApplicationServices();
        return services;
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
