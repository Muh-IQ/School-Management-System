using Modules.User.Infrastructure;

namespace Modules.User.WebAPI.Extensions
{
    public static class UserModuleSetup
    {

        public static IServiceCollection AddUserModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructureServices(configuration);
            //services.AddApplicationServices();
            //services.AddValidatorsFromAssemblyContaining<SchoolAddDTOValidator>();
            return services;
        }
    }
}
