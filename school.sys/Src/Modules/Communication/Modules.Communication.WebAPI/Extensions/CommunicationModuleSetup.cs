using Modules.Communication.Infrastructure;
namespace Modules.Communication.WebAPI.Extensions
{
    public static class CommunicationModuleSetup
    {
        public static IServiceCollection AddCommunicationModule(this IServiceCollection services)
        {
            services.AddInfrastructureServices();
            //services.AddApplicationServices();
            //services.AddValidatorsFromAssemblyContaining<SchoolAddDTOValidator>();
            return services;
        }
    }
}
