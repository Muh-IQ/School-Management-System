namespace Modules.IdP.Application.Common
{
    public class JWTSttings
    {
        public string SecretKey { get; set; } = default!;
        public string Issuer { get; set; } = default!;
        public string Audience { get; set; } = default!;
        public int ExpirationInMinutes { get; set; }
    }
}
