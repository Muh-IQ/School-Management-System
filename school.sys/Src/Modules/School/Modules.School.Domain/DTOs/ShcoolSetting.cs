using Modules.School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Domain.DTOs
{
    public class ShcoolSetting
    {
        public Languages Languages { get; set; }
        public Policies Policies { get; set; }
    }
}