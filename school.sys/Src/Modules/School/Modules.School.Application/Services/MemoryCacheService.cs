using Microsoft.Extensions.Caching.Memory;
using Modules.School.Application.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Application.Services
{
    internal class MemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheService(IMemoryCache memoryCache) => _memoryCache = memoryCache;

        public async Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> factory, TimeSpan? expiration = null)
        {
            if (_memoryCache.TryGetValue(key, out T result)) return result;

            result = await factory();

            var options = new MemoryCacheEntryOptions
            { AbsoluteExpirationRelativeToNow = expiration ?? TimeSpan.FromMinutes(10) };

            _memoryCache.Set(key, result, options);
            return result;
        }

        public Task RemoveAsync(string key)
        {
            _memoryCache.Remove(key);
            return Task.CompletedTask;
        }
    }
}
