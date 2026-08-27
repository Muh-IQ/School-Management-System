using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.IdP.Application.Helpers;
using Modules.IdP.Application.Services;
using Modules.IdP.Domain.BatchRecord;
using Modules.IdP.Domain.IRepositories;
using Modules.IdP.Infrastructure.Presistent;
using Modules.IdP.Infrastructure.Presistent.Seeds;
using Modules.IdP.Infrastructure.Repositories;
using Modules.IdP.Infrastructure.Repositories.BatchRepo;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.IdP.Infrastructure
{
    public static class DependencyInjectionInfrastructure
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // Register your singleton ConnectionProvider
            services.AddSingleton<ConnectionProvider>();
            services.AddScoped<IUserRegistrationWriter,
            UserRegistrationWriter>();

            // Use ConnectionProvider to get the connection string for DbContext
            services.AddDbContext<UserDbContext>((serviceProvider, options) =>
            {
                var connectionProvider = serviceProvider.GetRequiredService<ConnectionProvider>();
                options.UseSqlServer(connectionProvider.GetConnectionString());
            });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ISeeder, RoleSeeder>();
            return services;
        }
    }
}

