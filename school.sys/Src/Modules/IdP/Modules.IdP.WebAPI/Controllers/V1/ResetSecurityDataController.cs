using Microsoft.AspNetCore.Mvc;
using Modules.IdP.Application.IServices;
using Modules.IdP.WebAPI.Extensions;

namespace Modules.IdP.WebAPI.Controllers.V1
{
    [Route("api/V1/ResetSecurityData")]
    [ApiController]
    public class ResetSecurityDataController : ControllerBase
    {
        private readonly IResetSecurityDataService _resetSecurityDataService;
        private Guid id=Guid.Parse("0A0F30A5-0F5B-4B91-50E5-08DE8CF2783A");

        public ResetSecurityDataController(IResetSecurityDataService resetSecurityDataService)
        {
            _resetSecurityDataService = resetSecurityDataService;
        }

        #region ResetEmail

        [HttpPost("reset-email/session")]
        public async Task<IActionResult> OpenResetEmailSession()
        {
            var result = await _resetSecurityDataService.OpenResetEmailSessionAsync(id);

            return result.ToHttpResult();
        }
        [HttpPost("reset-email/send-otp-old-email")]
        public async Task<IActionResult> SendResetEmailOldEmailOtp([FromQuery] string sessionKey)
        {
            var result = await _resetSecurityDataService.SendResetEmailOldEmailCodeAsync(sessionKey);

            return result.ToHttpResult();
        }
        [HttpPost("reset-email/send-otp-new-email")]
        public async Task<IActionResult> SendResetEmaiNewEmaillOtp([FromQuery] string sessionKey)
        {
            var result = await _resetSecurityDataService.SendResetEmailNewEmailCodeAsync(sessionKey);

            return result.ToHttpResult();
        }

        [HttpPost("reset-email/verify-otp")]
        public async Task<IActionResult> VerifyResetEmailOtp([FromQuery] string sessionKey, [FromQuery] string otp )
        {
            var result = await _resetSecurityDataService.VerifyEmailResetAsync(sessionKey, otp );

            return result.ToHttpResult();
        }

        [HttpPost("reset-email/new-email")]
        public async Task<IActionResult> WriteNewEmail([FromQuery] string sessionKey, [FromQuery] string newEmail)
        {
            var result = await _resetSecurityDataService.WriteNewEmailAsync(sessionKey, newEmail);

            return result.ToHttpResult();
        }

        [HttpPost("reset-email")]
        public async Task<IActionResult> ResetEmail([FromQuery] string sessionKey)
        {
            var result = await _resetSecurityDataService.ResetEmailAsync(sessionKey);

            return result.ToHttpResult();
        }
        #endregion

        #region Password

        [HttpPost("reset-password/session")]
        public async Task<IActionResult> OpenResetPasswordSession()
        {
            var result =await _resetSecurityDataService.OpenResetPasswordSessionAsync(id);

            return result.ToHttpResult();
        }

        [HttpPost("reset-password/send-otp")]
        public async Task<IActionResult> SendResetPasswordOtp([FromQuery] string sessionKey)
        {
            var result =await _resetSecurityDataService.SendResetPasswordEmailCodeAsync(sessionKey);

            return result.ToHttpResult();
        }

        [HttpPost("reset-password/verify-otp")]
        public async Task<IActionResult> VerifyResetPasswordOtp([FromQuery] string sessionKey,[FromQuery] string otp)
        {
            var result =await _resetSecurityDataService.VerifyResetPasswordEmailAsync(sessionKey,otp);

            return result.ToHttpResult();
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromQuery] string sessionKey,[FromQuery] string newPassword)
        {
            var result =await _resetSecurityDataService.ResetPasswordAsync(sessionKey,newPassword);

            return result.ToHttpResult();
        }

        #endregion

    }
}
