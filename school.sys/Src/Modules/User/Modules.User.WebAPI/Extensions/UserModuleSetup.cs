using FluentValidation;
using Modules.User.Application;
using Modules.User.Application.Validators.Users;
using Modules.User.Infrastructure;

namespace Modules.User.WebAPI.Extensions;

public static class UserModuleSetup
{
    public static IServiceCollection AddUserModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Application services
        services.AddApplicationServices();

        // Infrastructure services
        services.AddInfrastructureServices(configuration);
        // FluentValidation
        services.AddValidatorsFromAssemblyContaining<CreateUserDtoValidator>();
        // Register validation filter
        services.AddScoped<FluentValidationFilter>();
        // Validation filter
        services.AddControllers(options =>
        {
            options.Filters.Add<FluentValidationFilter>();
        });
        return services;
    }
}