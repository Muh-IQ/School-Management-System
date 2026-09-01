using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Modules.IdP.Application.Common;
using Modules.IdP.Application.Common.Results;
using Modules.IdP.Application.Common.StaticError;
using Modules.IdP.Application.IServices;
using Modules.IdP.Domain.DTOs;
using Modules.IdP.Domain.IRepositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Modules.IdP.Application.Services
{
    public class AuthNService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly JWTSttings _settings;

        public AuthNService(IUserRepository userRepository, IOptions<JWTSttings> settings)
        {
            _userRepository = userRepository;
            _settings = settings.Value;
        }

        public Result<string> GenerateJWTToken(UserTokenDTO user)
        {
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Role, user.RoleCode)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_settings.SecretKey));

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: _settings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_settings.ExpirationInMinutes),
                signingCredentials: credentials);

           
             var AccessToken = new JwtSecurityTokenHandler().WriteToken(token);

            return Result<string>.Success(AccessToken);
        }

    }
}
