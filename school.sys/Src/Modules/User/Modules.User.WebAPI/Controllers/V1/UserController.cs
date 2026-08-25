using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.User.Application.Common.DTOs;
using Modules.User.Application.IServices;
using Modules.User.Domain.IRepositories;
using Modules.User.WebAPI.Common.DTOs;
using Modules.User.WebAPI.Extensions;

namespace Modules.User.WebAPI.Controllers.V1
{
    [Route("api/v1/user")]
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

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateUser(UpdateUserRequestDTO request)
        {
            var dto = new UpdateUserDTO
            {
                Id = Guid.Parse("a1111111-1111-1111-1111-111111111111"), // Temporary until UserId is retrieved from the authentication token.
                Name = request.Name,
                DateOfBirth = request.DateOfBirth,
                gender = request.Gender
            };

            var result = await _userService.UpdateAsync(dto);

            return result.ToHttpResult(StatusCodes.Status204NoContent);
        }
    }
}
