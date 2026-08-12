using Microsoft.Extensions.Options;
using Modules.Communication.Infrastructure.Common;
using System.Net;
using System.Net.Mail;
using Modules.Communication.Domain.ThirdParty.Email;

namespace Modules.Communication.Infrastructure.ThirdParty.Email
{
    internal class EmailService: IEmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }

        private async Task SendAsync(string email,string subject,string body)
        {

            using var mail = new MailMessage
            {
                From = new MailAddress(_settings.SenderEmail, _settings.SenderName),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mail.To.Add(email);

            using var client = new SmtpClient(_settings.SmtpServer, _settings.SmtpPort)
            {
                Credentials = new NetworkCredential(_settings.SenderEmail, _settings.Key),
                EnableSsl = true
            };

            await client.SendMailAsync(mail);
        }

        public async Task SendPasswordAsync(string email, string password)
        {
            string subject = "Your password";
            await SendAsync(email, subject, HTMLBodys.SendPasswordBody(password));
        }
       
    }
}
