using Microsoft.Extensions.Configuration;
using Modules.Communication.Infrastructure.ThirdParty.Email;


namespace Modules.Communication.Infrastructure.Extensions
{
    public static class EmailSettingsExtensions
    {
        //This method collection the data of EmailSettings from enviroment variable and code.
        public static EmailSettings CreateEmailSettings()
        {

         var password = Environment.GetEnvironmentVariable("EmailSettings__Password");

        if (string.IsNullOrWhiteSpace(password))
            {
                throw new InvalidOperationException(
                    "Email password is not configured in environment variables.");
            }

            return new EmailSettings
            {
                SmtpServer = "smtp.gmail.com",
                SmtpPort = 587,
                SenderEmail = "mohamedajaj0007@gmail.com",
                SenderName = "School System",
                Password = password
            };
        
        }
    }
}
