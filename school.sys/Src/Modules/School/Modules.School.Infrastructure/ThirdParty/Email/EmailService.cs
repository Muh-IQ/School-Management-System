using Microsoft.Extensions.Options;
using Modules.School.Domain.ThirdParty.Email;
using System.Net;
using System.Net.Mail;

namespace Modules.School.Infrastructure.ThirdParty.Email
{
    internal class EmailService: IEmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendAsync(EmailMessage message)
        {
            using var mail = new MailMessage
            {
                From = new MailAddress(_settings.SenderEmail, _settings.SenderName),
                Subject = message.Subject,
                Body = message.Body,
                IsBodyHtml = message.IsHtml
            };

            mail.To.Add(message.To);

            using var client = new SmtpClient(_settings.SmtpServer, _settings.SmtpPort)
            {
                Credentials = new NetworkCredential(_settings.SenderEmail, _settings.Password),
                EnableSsl = true
            };

            await client.SendMailAsync(mail);
        }
    }
}
