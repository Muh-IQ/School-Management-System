namespace Modules.Communication.Infrastructure.ThirdParty.Email
{
    public class EmailSettings
    {
        public string SmtpServer { get; set; } = default!;
        public int SmtpPort { get; set; }
        public string SenderEmail { get; set; } = default!;
        public string SenderName { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
