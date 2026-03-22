using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.User.Infrastructure.Presistent;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Infrastructure
{
    public static class DependencyInjectionInfrastructure
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register your singleton ConnectionProvider
            services.AddSingleton<ConnectionProvider>();

            // Use ConnectionProvider to get the connection string for DbContext
            services.AddDbContext<UserDbContext>((serviceProvider, options) =>
            {
                var connectionProvider = serviceProvider.GetRequiredService<ConnectionProvider>();
                options.UseSqlServer(connectionProvider.GetConnectionString());
            });

            return services;
        }
    }
}

