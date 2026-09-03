using Modules.IdP.Application.Common.Results;
using Modules.IdP.Application.Common.StaticError;
using Modules.IdP.Application.Helpers;
using Modules.IdP.Application.IServices;
using SharedKernel;
using SharedKernel.Events;

namespace Modules.IdP.Application.Services
{
    public class VerficationCodeService(ICacheService cacheService,IEventBus eventBus) : IVerificationCodeService
    {
        public async Task SendAsync(string sessionKey,string destination)
        {
            var otp = new OTPHelper().Generate();

            await cacheService.SetAsync($"OTP:{sessionKey}",otp,TimeSpan.FromMinutes(5));

            await eventBus.PublishAsync<UserVerifyIntegrationEvent>(new UserVerifyIntegrationEvent(destination,otp));
        }

        public async Task<Result> VerifyAsync(string sessionKey,string otp)
        {
            if (string.IsNullOrWhiteSpace(otp))
            {
                return Result.Failure(ErrorType.BadRequest,SessionErrors.VerificationCodeRequiredMessage());
            }

            var storedOtp = await cacheService.GetAsync<string>($"OTP:{sessionKey}");

            if (string.IsNullOrWhiteSpace(storedOtp))
            {
                return Result.Failure(ErrorType.NotFound,SessionErrors.VerficationCoseNotFoundMessage());
            }

            if (storedOtp != otp)
            {
                return Result.Failure(ErrorType.BadRequest,SessionErrors.InvalidVerificationCodeMessage(otp));
            }

            await cacheService.RemoveAsync($"OTP:{sessionKey}");

            return Result.Success();
        }
    }
}
