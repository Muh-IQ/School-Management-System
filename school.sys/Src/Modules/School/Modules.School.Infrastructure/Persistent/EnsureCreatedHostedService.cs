using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Modules.School.Infrastructure.Persistent;

/// <summary>
/// Ensures the in-memory SQLite database is created on application startup (used for testing).
/// </summary>
internal sealed class EnsureCreatedHostedService : IHostedService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public EnsureCreatedHostedService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _scopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<SchoolDbContext>();
        await context.Database.EnsureCreatedAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
