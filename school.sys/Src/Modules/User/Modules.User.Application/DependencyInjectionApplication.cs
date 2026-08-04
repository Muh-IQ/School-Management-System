using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Modules.User.Application.IServices;
using Modules.User.Application.Services;

namespace Modules.User.Application
{
    public static class DependencyInjectionApplication
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddScoped<ICacheService, MemoryCacheService>();

            return services;
        }
    }
}
