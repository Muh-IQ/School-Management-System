using Microsoft.Extensions.Caching.Memory;
using Modules.User.Application.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Application.Services
{
    public class MemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _cache;

        public MemoryCacheService(IMemoryCache cache)
        {
            _cache = cache;
        }
        public Task<T?> GetAsync<T>(string key)  //direct get the value by key and return object of any dto
        {
            _cache.TryGetValue(key, out T? value);

            return Task.FromResult(value);
        }
        public Task<T> GetOrCreateAsync<T>(
            string key,
            Func<Task<T>> factory,
            TimeSpan? expiration = null)
        {
            if (_cache.TryGetValue(key, out T? value))
            {
                return Task.FromResult(value!);
            }

            return CreateAndCacheAsync(key, factory, expiration);
        }
        private async Task<T> CreateAndCacheAsync<T>(
            string key,
            Func<Task<T>> factory,
            TimeSpan? expiration)
        {
            var value = await factory();

            SetCache(key, value, expiration);

            return value;
        }

        public Task RemoveAsync(string key)
        {
            _cache.Remove(key);

            return Task.CompletedTask;
        }

        public Task SetAsync<T>(
            string key,
            T value,
            TimeSpan? expiration = null)
        {
            SetCache(key, value, expiration);

            return Task.CompletedTask;
        }
        private void SetCache<T>(
            string key,
            T value,
            TimeSpan? expiration)
        {
            if (expiration.HasValue)
            {
                _cache.Set(
                    key,
                    value,
                    expiration.Value);
            }
            else
            {
                _cache.Set(key, value);
            }
        }
    }
}
