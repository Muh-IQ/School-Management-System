namespace Modules.School.Domain.Entities
{
    public class Policies:BaseEntity
    {
        public string Title { get; set; }
        public string sanitizeName { get; set; }
        public string PloicyType { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
