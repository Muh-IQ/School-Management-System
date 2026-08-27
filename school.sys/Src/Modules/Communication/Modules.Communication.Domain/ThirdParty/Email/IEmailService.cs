using Modules.Communication.Domain.ThirdParty.Email;

namespace Modules.Communication.Domain.ThirdParty.Email
{
    public interface IEmailService
    {
        Task SendPasswordAsync(string email, string password);
        Task SendOTPAsync(string email, string otp);
    }
}
