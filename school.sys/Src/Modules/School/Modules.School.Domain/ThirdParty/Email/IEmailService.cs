using Modules.School.Domain.ThirdParty.Email;

namespace Modules.School.Domain.ThirdParty.Email
{
    public interface IEmailService
    {
        Task SendAsync(EmailMessage message);

    }
}
