using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Domain.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime DOB { get; set; }

        public string gender { get; set; }

        public bool IsActive { get; set; }
    }
}
