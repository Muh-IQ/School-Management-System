using MediatR;
using Modules.Communication.Domain.ThirdParty.Email;
using SharedKernel.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Communication.Infrastructure.Subscriber;

public sealed class UserEmailSubscriber(
    IEmailService emailService)
    : INotificationHandler<UserRegisteredIntegrationEvent>
{
    public async Task Handle(
        UserRegisteredIntegrationEvent notification,
        CancellationToken cancellationToken)
    {
        await emailService.SendPasswordAsync(
            notification.Email,
            notification.Password);
    }
}