namespace Modules.IdP.Application.Common.Sessions
{
    public class ResetPasswordSession
    {
        public Guid UserId { get; set; }

        public string CurrentEmail { get; set; } = null!;

        public bool IsEmailVerified { get; set; }
    }
}
