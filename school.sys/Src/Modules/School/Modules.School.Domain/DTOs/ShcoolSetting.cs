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
        public Language Languages { get; set; }
        public Policy Policies { get; set; }
    }
}