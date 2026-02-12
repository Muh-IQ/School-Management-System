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
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<SchoolDbContext>(options =>
                options.UseSqlServer("Server=.;Database=SchoolManagement;Integrated Security=SSPI;TrustServerCertificate=True;"));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
