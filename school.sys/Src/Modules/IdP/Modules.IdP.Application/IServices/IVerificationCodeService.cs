using Modules.IdP.Application.Common.Results;

namespace Modules.IdP.Application.IServices
{
    public interface IVerificationCodeService
    {
        Task SendAsync(string sessionKey,string destination);

        Task<Result> VerifyAsync(string sessionKey,string otp);
    }
}
