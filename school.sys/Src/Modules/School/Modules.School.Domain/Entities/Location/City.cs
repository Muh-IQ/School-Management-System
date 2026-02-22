using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Domain.Entities.Place
{
    public class City : BaseEntity
    {
        public string Name { get; init; } = string.Empty;
        public Guid CountryId { get; init; }
      public virtual Country Country { get; set; }
    }
}
