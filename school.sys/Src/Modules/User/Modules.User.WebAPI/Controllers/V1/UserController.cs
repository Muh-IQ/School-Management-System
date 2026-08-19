using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.User.Application.Common.DTOs;
using Modules.User.Application.IServices;
using Modules.User.Domain.IRepositories;
using Modules.User.WebAPI.Extensions;

namespace Modules.User.WebAPI.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;


        public UserController(IUserService userService) {
            _userService = userService;
        }
        [HttpPost]
        public async Task <IActionResult> CreateUser(AddUserDTO dto){

            var result = await _userService.AddAsync(dto);
            return result.ToHttpResult(StatusCodes.Status202Accepted);
        }
    }
}
