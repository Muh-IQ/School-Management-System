using Modules.IdP.Application.Common.Results;
using Modules.IdP.Application.Common.StaticError;
using Modules.IdP.Application.IServices;
using System.Diagnostics;

namespace Modules.IdP.Application.Services
{
    public class SessionService(ICacheService cacheService) :ISessionService
    {
        public async Task<string> CreateAsync<T>(T session,TimeSpan expiration) where T: class
        {
            var key = $"RESET-SECURITY-DATA-{Guid.NewGuid():N}";
            await cacheService.SetAsync(key,session,expiration);

            return key;
        }
        public async Task<Result<T>> GetAsync<T>(string sessionKey) where T : class
        {

            var session = await cacheService.GetAsync<T>(sessionKey);

            if (session is null)
            {
                return Result<T>.Failure(ErrorType.NotFound,SessionErrors.NotFoundMessage(sessionKey));
            }

            return Result<T>.Success(session);
        }
        public async Task UpdateAsync<T>(string sessionKey,T session,TimeSpan expiration)where T : class
        {
            await cacheService.SetAsync(sessionKey,session,expiration);
        }

        public async  Task RemoveAsync(string sessionKey)
        {
            await cacheService.RemoveAsync(sessionKey);
        }
    }
}
