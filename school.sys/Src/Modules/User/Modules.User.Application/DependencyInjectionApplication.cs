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

            return services;
        }
    }
}
