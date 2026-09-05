using Modules.IdP.Application.Common;

namespace Modules.IdP.Application.Extensions
{
    public static class JWTSttingsExtension
    {
        public static JWTSttings CreateJWTSttings()
        {
            var secretKey = Environment.GetEnvironmentVariable("Jwt__SecretKey");

            if (string.IsNullOrWhiteSpace(secretKey))
            {
                throw new InvalidOperationException(
                    "JWT secret key is not configured in environment variables.");
            }

            return new JWTSttings
            {
                SecretKey = secretKey,
                Issuer = "SchoolManagementSystem",
                Audience = "SchoolManagementSystem",
                ExpirationInMinutes = 30
            };
        }
    }
}
