using Modules.School.Application;
using Modules.School.Infrastructure;
namespace Modules.School.WebAPI.Extensions
{
    public static class SchoolModuleSetup
    {
        public static IServiceCollection AddSchoolModule(this IServiceCollection services)
        {
            services.AddInfrastructureServices();
            services.AddApplicationServices();
            return services;
        }
    }
}
