using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.IdP.Application.IServices;
using Modules.IdP.WebAPI.Extensions;

namespace Modules.IdP.WebAPI.Controllers.V1
{
    [Route("api/v1/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCodeAsync(string code)
        {
            var result = await _roleService.GetByCodeAsync(code);

            return result.ToHttpResult();
        }

    }
}
