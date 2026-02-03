using Modules.School.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Domain.Entities
{
    public class SChool:BaseEntity
    {
        public string sanitizeName {  get; set; }
        public string Name {  get; set; }
        public string TimeZone { get; set; }
        public ContactInfo ContactInfo {  get; set; }
        public Guid LanguageId { get; set; }
        public virtual Language Language { get; set; }



    }
}
