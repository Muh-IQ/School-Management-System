using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Domain.Entities
{
    public class Policy:BaseEntity
    {
        public string Title { get; set; }
        public string sanitizeName { get; set; }
        public string PloicyType { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
