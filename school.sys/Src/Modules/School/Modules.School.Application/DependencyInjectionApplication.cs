using Microsoft.Extensions.DependencyInjection;
using Modules.School.Application.IServices;
using Modules.School.Application.Services;
using Modules.School.Domain.IThirdPartyServices;

namespace Modules.School.Application
{
    public static class DependencyInjectionApplication
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ISchoolService, SchoolService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IPolicyService, PolicyService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICityService, CityService>();


            services.AddSingleton<ITimeProvider, Services.TimeProvider>();
            return services;
        }
    }
}
