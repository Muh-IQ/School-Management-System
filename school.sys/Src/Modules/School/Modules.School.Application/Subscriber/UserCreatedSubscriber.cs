using MediatR;
using Modules.School.Application.IServices;
using SharedKernel.Events;

namespace Modules.School.Application.Subscriber;

public sealed class UserCreatedSubscriber(IUserSchoolService userSchoolService)
    : INotificationHandler<SharedKernel.Events.UserRegisteredIntegrationEvent>
{

    public async Task Handle(UserRegisteredIntegrationEvent notification, CancellationToken cancellationToken)
    {
        await userSchoolService.AddAsync(notification.UserId, notification.SchoolId);
    }
}
