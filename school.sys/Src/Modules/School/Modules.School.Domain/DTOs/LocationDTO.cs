using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Domain.DTOs
{
    public class LocationDTO
    {
        public Guid Id{ get; set; }
        public string Name{ get; set; } // will consum for country name , city name and area name 
    }
}
