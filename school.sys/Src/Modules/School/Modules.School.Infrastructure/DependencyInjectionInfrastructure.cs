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
        public static IServiceCollection AddInfrastructureServicesTesting(this IServiceCollection services, IConfiguration? configuration = null)
        {
            var useInMemory = configuration?["UseInMemoryDatabase"] == "true";

            if (useInMemory)
            {
                var connection = new SqliteConnection("DataSource=:memory:");
                connection.Open();
                services.AddSingleton(connection);
                services.AddDbContext<SchoolDbContext>(options => options.UseSqlite(connection));
                services.AddHostedService<EnsureCreatedHostedService>();
            }
            else
            {
                services.AddDbContext<SchoolDbContext>(options =>
                    options.UseSqlServer("Server=.;Database=SchoolManagement;Integrated Security=SSPI;TrustServerCertificate=True;"));
            }

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ISchoolRepository, SchoolRepositories>();
            return services;
        }
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<SchoolDbContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ISchoolRepository, SchoolRepository>();

            return services;
        }
    }
}
