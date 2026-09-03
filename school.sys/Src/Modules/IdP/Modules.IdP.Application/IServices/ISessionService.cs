using Modules.IdP.Application.Common.Results;

namespace Modules.IdP.Application.IServices
{
    public interface ISessionService
    {
        Task<string> CreateAsync<T>(T session,TimeSpan expiration)where T : class;

        Task<Result<T>> GetAsync<T>(string sessionKey)where T : class;

        Task UpdateAsync<T>(string sessionKey,T session,TimeSpan expiration)where T : class;

        Task RemoveAsync(string sessionKey);
    }
}
