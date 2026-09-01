namespace Modules.IdP.Domain.DTOs
{
    public class UserTokenDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string? RoleCode { get; set; }
    }
}
