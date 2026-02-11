using Modules.School.Domain.DTOs;

namespace Modules.School.Domain.Entities
{
    public class School:BaseEntity
    {
        public string sanitizeName {  get; set; }
        public string Name {  get; set; }
        public string TimeZone { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid LanguageId { get; set; }
        public virtual Language Language { get; set; }
        public Guid PolicyId { get; set; }
        public virtual Policy Policy { get; set; }

    }
}
