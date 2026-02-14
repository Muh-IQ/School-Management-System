using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Infrastructure.ThirdParty.Email
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
