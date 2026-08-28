using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.IdP.Application.Common.DTOs;

public class AddUserDTO
{

    public string Name { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }
    public Guid SchoolID { get; set; }

    public DateTime DateOfBirth { get; set; }

    public bool gender { get; set; }

}
