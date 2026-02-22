using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Domain.Entities.Place
{
    public class Area:BaseEntity
    {
        public string Name { get; init; } = string.Empty;
        public Guid CityId { get; init; }
        public virtual City City { get; set; }
    }
}
