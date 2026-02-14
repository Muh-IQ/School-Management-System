using Modules.Communication.Domain.ThirdParty.Email;

namespace Modules.Communication.Domain.ThirdParty.Email
{
    public interface IEmailService
    {
        Task SendAsync(EmailMessage message);

    }
}
