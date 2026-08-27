using FluentValidation;
using Modules.IdP.Application;
using Modules.IdP.Infrastructure;
using Modules.IdP.WebAPI.ExceptionHandling.Handlers;
using Modules.IdP.WebAPI.Filters;
using Modules.IdP.WebAPI.Validators.Users;

namespace Modules.IdP.WebAPI.Extensions
{
    public static class UserModuleSetup
    {
        public static IServiceCollection AddUserModule(this IServiceCollection services)
        {
            services.AddInfrastructureServices();
            services.AddApplicationServices();

            services.AddValidatorsFromAssemblyContaining<AddUserDTOValidator>();
            services.AddExceptionHandler<UnhandledExceptionHandler>();
            services.AddProblemDetails();
            // Register validation filter in DI

            services.AddScoped<FluentValidationFilter>();

            // Register MVC + global validation filter
            services.AddControllers(options =>
            {
                options.Filters.Add<FluentValidationFilter>();
            });
            return services;
        }
    }
}
