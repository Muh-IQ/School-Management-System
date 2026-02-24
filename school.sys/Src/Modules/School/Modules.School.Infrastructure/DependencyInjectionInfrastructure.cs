using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.School.Domain.IRepositories;
using Modules.School.Infrastructure.Persistent;
using Modules.School.Infrastructure.Repositories;


namespace Modules.School.Infrastructure
{
    public static class DependencyInjectionInfrastructure
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            // Register your singleton ConnectionProvider
            services.AddSingleton<ConnectionProvider>();

            // Use ConnectionProvider to get the connection string for DbContext
            services.AddDbContext<SchoolDbContext>((serviceProvider, options) =>
            {
                var connectionProvider = serviceProvider.GetRequiredService<ConnectionProvider>();
                options.UseSqlServer(connectionProvider.GetConnectionString());
            });


            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ISchoolRepository, SchoolRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IAreaRepository, AreaRepository>();


            return services;
        }
    }
}
