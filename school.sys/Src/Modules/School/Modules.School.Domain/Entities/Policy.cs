namespace Modules.School.Domain.Entities
{
    public class Policy:BaseEntity
    {
        public string Title { get; set; }
        public string sanitizeName { get; set; }
        public string PolicyType { get; set; }
        public string Description { get; set; }
        public bool IsDefault { get; set; }
    }
}
