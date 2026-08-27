using Microsoft.Extensions.Hosting;
using Modules.IdP.Domain.BatchRecord;


namespace Modules.IdP.Application.Helpers;

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
    