using Microsoft.Extensions.DependencyInjection;
using Modules.School.Application.IServices;
using Modules.School.Application.Services;

namespace Modules.School.Application
{
    public static class DependencyInjectionApplication
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ISchoolService, SchoolService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IPolicyService, PolicyService>();
            return services;
        }
    }
}
