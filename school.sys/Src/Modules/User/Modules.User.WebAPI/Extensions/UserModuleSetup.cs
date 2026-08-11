using FluentValidation;
using Modules.User.Application;
using Modules.User.Infrastructure;
using Modules.User.WebAPI.Filters;
using Modules.User.WebAPI.Validators.Users;

namespace Modules.User.WebAPI.Extensions
{
    public static class UserModuleSetup
    {

        public static IServiceCollection AddUserModule(this IServiceCollection services)
        {
            services.AddInfrastructureServices();
            services.AddApplicationServices();
            services.AddValidatorsFromAssemblyContaining<AddUserDTOValidator>();

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
