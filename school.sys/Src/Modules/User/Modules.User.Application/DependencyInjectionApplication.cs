using Microsoft.Extensions.DependencyInjection;
using Modules.User.Application.Helpers;
using Modules.User.Application.IServices;
using Modules.User.Application.Services;
using Modules.User.Domain.IRepositories;

namespace Modules.User.Application
{
    public static class DependencyInjectionApplication
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheService, MemoryCacheService>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddSingleton<MicroBatch<Domain.Entities.User>>(sp =>
            {
                var repository = sp.GetRequiredService<IGenericRepository<Domain.Entities.User>>();

                return new MicroBatch<Domain.Entities.User>(
                    maxSizeToFlush: 100,
                    maxTimeToFlush: TimeSpan.FromMilliseconds(100),
                    onFlush: async users => await repository.AddRangeAsync(users));
            });


            services.AddSingleton<MicroBatch<Domain.Entities.UserRole>>(sp =>
            {
                var repository = sp.GetRequiredService<IGenericRepository<Domain.Entities.UserRole>>();

                return new MicroBatch<Domain.Entities.UserRole>(
                    maxSizeToFlush: 100,
                    maxTimeToFlush: TimeSpan.FromMilliseconds(100),
                    onFlush: async UserRoles => await repository.AddRangeAsync(UserRoles));
            });


            services.AddHostedService<UserBatchWorker>();
            services.AddHostedService<UserRoleBatchWorker>();
            return services;
        }
    }
}
