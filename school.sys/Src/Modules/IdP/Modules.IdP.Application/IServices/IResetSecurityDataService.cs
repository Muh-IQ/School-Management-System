using Modules.IdP.Application.Common.Results;
using Modules.IdP.Application.Common.Sessions;

namespace Modules.IdP.Application.IServices
{
    public interface IResetSecurityDataService
    {
        // Email
        Task<Result<string>>OpenResetEmailSessionAsync(Guid userId);

        Task<Result>SendResetEmailOldEmailCodeAsync(string sessionKey);

        Task<Result> VerifyEmailResetAsync(string sessionKey, string otp);
        Task<Result>WriteNewEmailAsync(string sessionKey,string newEmail);
        Task<Result>SendResetEmailNewEmailCodeAsync(string sessionKey);

        Task<Result>ResetEmailAsync(string sessionKey);


        // Password
        Task<Result<string>>OpenResetPasswordSessionAsync(Guid userId);

        Task<Result>SendResetPasswordEmailCodeAsync(string sessionKey);

        Task<Result>VerifyResetPasswordEmailAsync(string sessionKey,string otp);

        Task<Result>ResetPasswordAsync(string sessionKey,string newPassword);
    }
}
