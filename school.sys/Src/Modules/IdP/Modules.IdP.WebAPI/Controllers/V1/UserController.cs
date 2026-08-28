using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.IdP.Application.Common.DTOs;
using Modules.IdP.Application.IServices;
using Modules.IdP.Domain.IRepositories;
using Modules.IdP.WebAPI.Common.RequestDTOs;
using Modules.IdP.WebAPI.Extensions;


namespace Modules.IdP.WebAPI.Controllers.V1
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
        // =========================
        // Reset Email
        // =========================

        [HttpPost("reset-email/session")]
        public async Task<IActionResult> OpenResetEmailSession()
        {
            var result = await _userService.OpenSessionAsync();

            return result.ToHttpResult();
        }

        [HttpPost("reset-email/send-otp")]
        public async Task<IActionResult> SendResetEmailOtp([FromQuery] string sessionKey)
        {
            var result = await _userService.SendVerficationCodeUserAsync(sessionKey);

            return result.ToHttpResult();
        }

        [HttpPost("reset-email/verify-otp")]
        public async Task<IActionResult> VerifyResetEmailOtp([FromQuery] string otp,[FromQuery] string sessionKey)
        {
            var result = await _userService.VerifyUserAsync(otp, sessionKey);

            return result.ToHttpResult();
        }

        [HttpPost("reset-email/new-email")]
        public async Task<IActionResult> WriteNewEmail([FromQuery] string sessionKey,[FromQuery] string newEmail)
        {
            var result = await _userService.WriteNewEmailAsync(sessionKey, newEmail);

            return result.ToHttpResult();
        }

        [HttpPost("reset-email")]
        public async Task<IActionResult> ResetEmail([FromQuery] string sessionKey)
        {
            var result = await _userService.ResetEmailAsync(sessionKey);

            return result.ToHttpResult();
        }
    }
}
