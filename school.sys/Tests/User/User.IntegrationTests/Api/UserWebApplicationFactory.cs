using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Modules.IdP.Infrastructure.Presistent;
using SharedKernel;
using System;

public class UserWebApplicationFactory
    : WebApplicationFactory<Program>
{
    private readonly string _dbName = Guid.NewGuid().ToString();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.RemoveAll<IEventBus>();
            services.AddSingleton<IEventBus, NoOpEventBus>();

            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<UserDbContext>));

            if (descriptor != null)
                services.Remove(descriptor);

            services.AddDbContext<UserDbContext>(options =>
            {
                options.UseInMemoryDatabase(_dbName);
            });
        });
    }

    private sealed class NoOpEventBus : IEventBus
    {
        public Task PublishAsync<T>(T integrationEvent, CancellationToken cancellationToken = default)
            where T : class, IIntegrationEvent => Task.CompletedTask;
    }
}
