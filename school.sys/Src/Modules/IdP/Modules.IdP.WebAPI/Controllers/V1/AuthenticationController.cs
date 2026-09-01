using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.IdP.Application.IServices;
using Modules.IdP.Domain.DTOs;
using Modules.IdP.WebAPI.Extensions;

namespace Modules.IdP.WebAPI.Controllers.V1
{
    [Route("api/v1/Authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authNService;
        public AuthenticationController(IAuthenticationService authNService)
        {
            _authNService = authNService;
        }

        //This api for test Generate token
        [HttpPost]
        public IActionResult GenerateToken(UserTokenDTO user)
        {
            var result = _authNService.GenerateJWTToken(user);
            return result.ToHttpResult();
        }
    }
}
