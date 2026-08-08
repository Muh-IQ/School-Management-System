using MediatR;
using SharedKernel.Events;

namespace Modules.School.Application.Subscriber;

internal sealed class UserCreatedSubscriber
    : INotificationHandler<SharedKernel.Events.UserRegisteredIntegrationEvent>
{

    public Task Handle(UserRegisteredIntegrationEvent notification, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
