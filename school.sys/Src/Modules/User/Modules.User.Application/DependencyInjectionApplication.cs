using Microsoft.Extensions.DependencyInjection;
using Modules.User.Application.Helpers;
using Modules.User.Application.IServices;
using Modules.User.Application.Services;
using Modules.User.Domain.BatchRecord;
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
            services.AddScoped<IUserService, UserService>();

            //services.AddSingleton<MicroBatch<Domain.Entities.User>>(sp =>
            //{
            //    var repository = sp.GetRequiredService<IGenericRepository<Domain.Entities.User>>();

            //    return new MicroBatch<Domain.Entities.User>(
            //        maxSizeToFlush: 100,
            //        maxTimeToFlush: TimeSpan.FromMilliseconds(100),
            //        onFlush: async users => await repository.AddRangeAsync(users));
            //});

            //services.AddSingleton<MicroBatch<Domain.Entities.User>>(sp =>
            //{
            //    var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();

            //    return new MicroBatch<Domain.Entities.User>(
            //        maxSizeToFlush: 100,
            //        maxTimeToFlush: TimeSpan.FromMilliseconds(100),
            //        onFlush: async users =>
            //        {
            //            using var scope = scopeFactory.CreateScope();

            //            var repository =
            //                scope.ServiceProvider
            //                    .GetRequiredService<IGenericRepository<Domain.Entities.User>>();

            //            await repository.AddRangeAsync(users);
            //        });
            //});

            //services.AddSingleton<MicroBatch<Domain.Entities.UserRole>>(sp =>
            //{
            //    var repository = sp.GetRequiredService<IGenericRepository<Domain.Entities.UserRole>>();

            //    return new MicroBatch<Domain.Entities.UserRole>(
            //        maxSizeToFlush: 100,
            //        maxTimeToFlush: TimeSpan.FromMilliseconds(100),
            //        onFlush: async UserRoles => await repository.AddRangeAsync(UserRoles));
            //});
            //services.AddSingleton<MicroBatch<Domain.Entities.UserRole>>(sp =>
            //{
            //    var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();

            //    return new MicroBatch<Domain.Entities.UserRole>(
            //        maxSizeToFlush: 100,
            //        maxTimeToFlush: TimeSpan.FromMilliseconds(100),
            //        onFlush: async userRoles =>
            //        {
            //            using var scope = scopeFactory.CreateScope();

            //            var repository =
            //                scope.ServiceProvider
            //                    .GetRequiredService<IGenericRepository<Domain.Entities.UserRole>>();

            //            await repository.AddRangeAsync(userRoles);
            //        });
            //});
            services.AddSingleton<MicroBatch<UserRegistrationBatchItem>>(sp =>
            {
                var scopeFactory =
                    sp.GetRequiredService<IServiceScopeFactory>();

                return new MicroBatch<UserRegistrationBatchItem>(
                    maxSizeToFlush: 100,
                    maxTimeToFlush: TimeSpan.FromMilliseconds(100),

                    onFlush: async registrations =>
                    {
                        await using var scope =
                            scopeFactory.CreateAsyncScope();

                        var writer =
                            scope.ServiceProvider
                                .GetRequiredService<IUserRegistrationWriter>();

                        await writer.WriteAsync(registrations);
                    });
            });


            services.AddHostedService<UserBatchWorker>();
            //services.AddHostedService<UserBatchWorker>();
            //services.AddHostedService<UserRoleBatchWorker>();
            return services;
        }
    }
}
