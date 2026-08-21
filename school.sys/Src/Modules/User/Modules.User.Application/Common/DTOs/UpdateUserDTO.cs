namespace Modules.User.Application.Common.DTOs
{
    public class UpdateUserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool gender { get; set; }
    }
}
