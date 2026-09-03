using Microsoft.Extensions.DependencyInjection;
using Modules.IdP.Application.Services;
using Modules.IdP.Application.Helpers;
using Modules.IdP.Application.IServices;
using Modules.IdP.Application.Services;
using Modules.IdP.Domain.BatchRecord;
using Modules.IdP.Domain.IRepositories;

namespace Modules.IdP.Application
{
    public static class DependencyInjectionApplication
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddMemoryCache();
            services.AddSingleton<ICacheService, MemoryCacheService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IResetSecurityDataService, ResetSecurityDataService>();
            services.AddScoped<IVerificationCodeService, VerficationCodeService>();
            services.AddScoped<ISessionService, SessionService>();

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
