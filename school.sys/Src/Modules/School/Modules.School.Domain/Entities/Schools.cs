using Modules.School.Domain.DTOs;

namespace Modules.School.Domain.Entities
{
    public class Schools: BaseEntity
    {
        public string sanitizeName {  get; set; }
        public string Name {  get; set; }
        public string TimeZone { get; set; }
        public ContactInfo ContactInfo {  get; set; }
        public Guid LanguageId { get; set; }
        public virtual Languages Language { get; set; }
        public Guid PolicyId { get; set; }
        public virtual Policies Policy { get; set; }

    }
}
