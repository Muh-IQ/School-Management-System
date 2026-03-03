namespace Modules.School.Domain.DTOs
{
    public class SchoolListItemDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LanguageCode { get; set; }
        public string PolicyTitle { get; set; }
        public string CountryName { get; set; }
        public string sanitizeName { get; set; }
    }
}
