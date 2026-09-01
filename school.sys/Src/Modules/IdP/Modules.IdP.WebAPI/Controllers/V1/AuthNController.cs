using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.IdP.Application.IServices;
using Modules.IdP.WebAPI.Extensions;

namespace Modules.IdP.WebAPI.Controllers.V1
{
    [Route("api/v1/AuthN")]
    [ApiController]
    public class AuthNController : ControllerBase
    {
        private readonly IAuthNService _authNService;
        public AuthNController(IAuthNService authNService)
        {
            _authNService = authNService;
        }

        //This api for test Generate token
        [HttpPost]
        public async Task<IActionResult> GenerateToken(Guid Id)
        {
            var result = await _authNService.GenerateTokenAsync(Id);
            return result.ToHttpResult();
        }
    }
}
