using Microsoft.Extensions.Hosting;
using Modules.User.Domain.BatchRecord;


namespace Modules.User.Application.Helpers;

public class UserBatchWorker(
    MicroBatch<UserRegistrationBatchItem> batch)
    : BackgroundService
{
    protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        await batch.Run(stoppingToken);
    }
}
    