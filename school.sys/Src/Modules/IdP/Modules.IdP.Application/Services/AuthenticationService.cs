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
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly JWTSttings _settings;
        private readonly ICacheService _cacheService;
        public AuthenticationService(IUserRepository userRepository, IOptions<JWTSttings> settings,ICacheService cacheService)
        {
            _userRepository = userRepository;
            _settings = settings.Value;
            _cacheService = cacheService;
        }

        private string GenerateJWTToken(UserTokenDTO user)
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

            return AccessToken;
        }

        public async Task<Result<string>> LoginAsync(string Email, string Password)
        {
            var attemptKey = $"LOGIN-ATTEMPTS-{Email.ToLowerInvariant()}";

            var attempts = await _cacheService.GetAsync<int>(attemptKey);

            if (attempts >= 5)
            {
                return Result<string>.Failure(ErrorType.Unauthorized,UserErrors.AccountLockedMessage());
            }

            var user = await _userRepository
                .GetUserByEmailAndPasswordAsync(Email, Password);

            if (user == null)
            {
                attempts++;

                await _cacheService.SetAsync(attemptKey,attempts,TimeSpan.FromMinutes(15));

                if (attempts >= 5)
                {
                    return Result<string>.Failure(ErrorType.Unauthorized,UserErrors.AccountLockedMessage());
                }

                return Result<string>.Failure(ErrorType.Unauthorized,UserErrors.InvalidCredentialsMessage());
            }

            await _cacheService.RemoveAsync(attemptKey);

            var token = GenerateJWTToken(user);

            var cacheKey = $"USER-TOKEN-{user.Id}";

            await _cacheService.SetAsync(cacheKey,token,TimeSpan.FromHours(1));

            return Result<string>.Success(token);
        }
    }
}
