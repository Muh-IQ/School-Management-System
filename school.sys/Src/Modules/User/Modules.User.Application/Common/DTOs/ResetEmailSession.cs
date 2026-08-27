using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Application.Common.DTOs
{
    public class ResetEmailSession
    {
        public bool IsConfirmOldEmail { get; set; }
        public bool IsConfirmNewEmail { get; set; }
        public bool IsNewEmailExist { get; set; }
        public string? NewEmail { get; set; }
    }
}
