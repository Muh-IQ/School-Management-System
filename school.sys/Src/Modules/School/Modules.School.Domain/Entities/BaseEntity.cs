namespace Modules.School.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public DateTime CreateAt { get; set; } 
        public DateTime UpdateAt { get; set; }
    }
}
