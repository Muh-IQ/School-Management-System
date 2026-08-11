using Microsoft.Extensions.Hosting;


namespace Modules.User.Application.Helpers;

public sealed class UserBatchWorker : BackgroundService
{
    private readonly MicroBatch<Domain.Entities.User> _batch;

    public UserBatchWorker(MicroBatch<Domain.Entities.User> batch)
    {
        _batch = batch;
    }

    protected override Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        return _batch.Run(stoppingToken);
    }
}
