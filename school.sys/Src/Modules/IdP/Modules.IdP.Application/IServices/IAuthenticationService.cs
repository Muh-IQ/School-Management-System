using Modules.IdP.Application.Common.Results;
using Modules.IdP.Domain.DTOs;

namespace Modules.IdP.Application.IServices
{
    public interface IAuthenticationService
    {
        Task<Result<string>> LoginAsync(string Email, string Password);
    }
}
