using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.User.Application.IServices;
using Modules.User.WebAPI.Extensions;

namespace Modules.User.WebAPI.Controllers.V1
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
