namespace Modules.School.Domain.DTOs
{
    public class SchoolAddDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid LanguageId { get; set; }
        public string PolicyTitle { get; set; }
        public string PolicyDescription { get; set; }
        public string PolicyType { get; set; }
    }
}
