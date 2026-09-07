using Modules.IdP.WebAPI.Common.RequestDTOs;
using Microsoft.AspNetCore.Mvc;
using Modules.IdP.Application.IServices;
using Modules.IdP.WebAPI.Extensions;

namespace Modules.IdP.WebAPI.Controllers.V1
{
    [Route("api/v1/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _authenticationService.LoginAsync(request.Email,request.Password);

            return result.ToHttpResult();
        }
    }
}
