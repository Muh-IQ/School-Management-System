using Modules.School.Domain.DTOs;
using Modules.School.Domain.Entities.Place;

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
        public Guid CountryId { get; set; }
        public virtual Country Country { get; set; }
        public Guid CityId { get; set; }
        public virtual City City { get; set; }
        public Guid AreaId { get; set; }
        public virtual Area Area { get; set; }

    }
}
