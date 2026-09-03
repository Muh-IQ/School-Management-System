namespace Modules.IdP.Application.Common.Sessions
{
    public class ResetEmailSession
    {
        public Guid UserId { get; set; }

        public string OldEmail { get; set; } = null!;

        public string? NewEmail { get; set; }

        public bool IsOldEmailVerified { get; set; }

        public bool IsNewEmailVerified { get; set; }
    }
}
