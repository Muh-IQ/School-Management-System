using Modules.School.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Domain.Entities
{
<<<<<<< HEAD
    public class SChool:BaseEntity
=======

    public class Schools: BaseEntity

>>>>>>> e7eafb8d197301df9bc47ef1584c7531b9013314
    {
        public string sanitizeName {  get; set; }
        public string Name {  get; set; }
        public string TimeZone { get; set; }
        public ContactInfo ContactInfo {  get; set; }
        public Guid LanguageId { get; set; }
<<<<<<< HEAD
        public virtual Language Language { get; set; }
=======
        public virtual Languages Language { get; set; }
        public Guid PolicyId { get; set; }
        public virtual Policies Policy { get; set; }
>>>>>>> e7eafb8d197301df9bc47ef1584c7531b9013314



    }
}
