using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Domain.Entities
{
    public class UserSchool : BaseEntity
    {
        public Guid UserId { get; set;}
        public Guid SchoolId { get; set; }
        public virtual School School { get; set;}
    }
}
