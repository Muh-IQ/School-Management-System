using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Domain.DTOs
{
    public class CreateUserDTO
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public DateTime DOB { get; set; }

        public bool Gender { get; set; }

        public DateTime StartDate { get; set; }

    }
}
