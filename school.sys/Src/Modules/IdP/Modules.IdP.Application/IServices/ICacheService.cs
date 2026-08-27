using Modules.IdP.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.IdP.Application.IServices
{
    public interface ICacheService
    {
        Task<T?> GetAsync<T>(string key);

        Task SetAsync<T>(string key, T value, TimeSpan? expiration = null);

        Task RemoveAsync(string key);

        Task<T> GetOrCreateAsync<T>(
            string key,
            Func<Task<T>> factory,
            TimeSpan? expiration = null);
    }

}
