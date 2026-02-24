namespace Modules.School.Domain.DTOs
{
    public class SchoolDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string LanguageCode { get; set; }
        public string LanguageName { get; set; }
        public string PolicyTitle { get; set; }
        public string PolicyDescription { get; set; }
        public string PolicyType { get; set; }

    }
}
