using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.Communication.Domain.ThirdParty.Email;
using Modules.Communication.Domain.ThirdParty.Security;

namespace Modules.Communication.WebAPI.Controllers
{
    [ApiController]
    [Route("api/test-email")]
    public class TestEmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IOtpGenerator _tpGenerator;

        public TestEmailController(IEmailService emailService, IOtpGenerator otpGenerator)
        {
            _emailService = emailService;
            _tpGenerator = otpGenerator;
        }

        [HttpPost]
        public async Task<IActionResult> Send()
        {
            var message = new EmailMessage
            {
                To = "addh3584@gmail.com",
                Subject = "This is your code",
                Body = _tpGenerator.Generate(),
                IsHtml = false
            };

            await _emailService.SendAsync(message);

            return Ok();
        }
    }
}
