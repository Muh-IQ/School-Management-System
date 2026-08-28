using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.IdP.Application.Helpers
{
    public class UserRoleBatchWorker : BackgroundService
    {
        private readonly MicroBatch<Domain.Entities.UserRole> _batch;

        public UserRoleBatchWorker(MicroBatch<Domain.Entities.UserRole> batch)
        {
            _batch = batch;
        }

        protected override Task ExecuteAsync(
            CancellationToken stoppingToken)
        {
            return _batch.Run(stoppingToken);
        }
    }
}
