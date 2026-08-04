using Microsoft.Extensions.DependencyInjection;
using Modules.User.Application.IServices;

namespace Modules.User.Application
{
    public static class DependencyInjectionApplication
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRoleService, IRoleService>();
            services.AddScoped<IUserService, IUserService>();
            return services;
        }
    }
}
