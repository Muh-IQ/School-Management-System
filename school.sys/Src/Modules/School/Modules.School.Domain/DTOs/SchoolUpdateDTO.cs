namespace Modules.School.Domain.DTOs
{
    public class SchoolUpdateDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid LanguageId { get; set; }
        public Guid PolicyId { get; set; }
    }
}
