using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.IdP.Application.Helpers
{
    public sealed class MicroBatch<T>
    {
        private readonly int _maxSizeToFlush;
        private readonly TimeSpan _maxTimeToFlush;
        private readonly Func<List<T>, Task> _onFlush;

        private readonly List<T> _entities = [];
        private readonly SemaphoreSlim _signal = new(0);

        public MicroBatch(
        int maxSizeToFlush,
        TimeSpan maxTimeToFlush,
        Func<List<T>, Task> onFlush)
        {
            if (maxSizeToFlush <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxSizeToFlush));

            if (maxTimeToFlush <= TimeSpan.Zero)
                throw new ArgumentOutOfRangeException(nameof(maxTimeToFlush));

            _onFlush = onFlush
                ?? throw new ArgumentNullException(nameof(onFlush));

            _maxSizeToFlush = maxSizeToFlush;
            _maxTimeToFlush = maxTimeToFlush;
        }

        public void Add(T entity)
        {
            lock (_entities)
            {
                _entities.Add(entity);

                if (_entities.Count >= _maxSizeToFlush)
                {
                    _signal.Release();
                }
            }
        }

        public async Task Run(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var timerTask = Task.Delay(
                    _maxTimeToFlush,
                    cancellationToken);

                var signalTask = _signal.WaitAsync(
                    cancellationToken);

                await Task.WhenAny(
                    timerTask,
                    signalTask);

                await Flush();
            }
        }
        private async Task Flush()
        {
            List<T> batch;
            lock (_entities)
            {
                if (_entities.Count == 0)
                    return;
                batch = new List<T>(_entities);
                _entities.Clear();
            }

            try
            {
                await _onFlush(batch);
            }
            catch (Exception ex)
            {
                // logging and retry
            }
        }
    }
}
