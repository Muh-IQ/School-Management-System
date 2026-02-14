using Modules.School.Domain.ThirdParty.Email;
using Modules.School.Domain.ThirdParty.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.School.Application.Register
{
    public class RegisterHandler
    {
        private readonly IEmailService _emailService;
        private readonly IOtpGenerator _otpGenerator;

        public RegisterHandler(
            IEmailService emailService,
            IOtpGenerator otpGenerator)
        {
            _emailService = emailService;
            _otpGenerator = otpGenerator;
        }

        public async Task Handle(string email)
        {
            var otp = _otpGenerator.Generate();

            var message = new EmailMessage
            {
                To = email,
                Subject = "Email Confirmation",
                Body = $"Your OTP is: {otp}",
                IsHtml = false
            };

            await _emailService.SendAsync(message);
        }

    }
}
