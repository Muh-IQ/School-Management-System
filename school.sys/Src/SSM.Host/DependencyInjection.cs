using Modules.School.Application.Subscriber;

namespace SSM.Host.DependencyInjection;

public static class MediatRRegistration
{
    public static IServiceCollection RegisterSubscriptions(
        this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(
                typeof(UserCreatedSubscriber).Assembly
            );
        });

        return services;
    }
}