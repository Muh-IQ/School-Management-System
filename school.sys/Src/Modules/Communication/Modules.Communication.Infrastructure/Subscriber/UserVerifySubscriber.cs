using MediatR;
using Modules.Communication.Domain.ThirdParty.Email;
using SharedKernel.Events;

namespace Modules.Communication.Infrastructure.Subscriber
{
    public sealed class UserVerifySubscriber(IEmailService emailService) : INotificationHandler<UserVerifyIntegrationEvent>
    {
        public async Task Handle(UserVerifyIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await emailService.SendOTPAsync(notification.email, notification.otp);
        }
    }
}
