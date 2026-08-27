namespace Modules.User.WebAPI.Common.RequestDTOs
{
    public class UpdateUserRequestDTO
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
    }
}