using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modules.Communication.Domain.ThirdParty.Email;

namespace Modules.Communication.WebAPI.Controllers
{
    [ApiController]
    [Route("api/test-email")]
    public class TestEmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public TestEmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> Send()
        {
            string email = "addh3584@gmail.com";
            string password = "GG1122GG";

            await _emailService.SendPasswordAsync(email, password);

            return Ok();
        }
    }
}
