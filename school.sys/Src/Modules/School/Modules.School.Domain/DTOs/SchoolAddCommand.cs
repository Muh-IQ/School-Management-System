using Modules.School.Domain.Entities.Place;

namespace Modules.School.Domain.DTOs
{
    public class SchoolAddCommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid LanguageId { get; set; }
        public string? PolicyTitle { get; set; }
        public string? PolicyDescription { get; set; }
    }
}
