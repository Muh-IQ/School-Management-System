using Modules.School.Application;
using Modules.School.Infrastructure;
namespace Modules.School.WebAPI.Extensions
{
    public static class SchoolModuleSetup
    {
        public static IServiceCollection AddSchoolModule(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddInfrastructureServices(configuration);
            services.AddApplicationServices();
            return services;
        }
    }
}
