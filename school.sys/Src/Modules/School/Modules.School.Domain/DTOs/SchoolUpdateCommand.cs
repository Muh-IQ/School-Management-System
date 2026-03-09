namespace Modules.School.Domain.DTOs
{
    public class SchoolUpdateCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid LanguageId { get; set; }
        public Guid CountryId { get; set; }
        public Guid CityId { get; set; }
        public Guid AreaId { get; set; }
        public string? PolicyTitle { get; set; }
        public string? PolicyDescription { get; set; }
    }
}
