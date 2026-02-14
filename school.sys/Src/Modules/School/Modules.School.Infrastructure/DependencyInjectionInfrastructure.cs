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
            services.AddDbContextPool<SchoolDbContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ISchoolRepository, SchoolRepository>();

            return services;
        }
    }
}
