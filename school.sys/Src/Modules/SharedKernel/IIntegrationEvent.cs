using MediatR;
namespace SharedKernel;

public interface IIntegrationEvent : INotification
{
    Guid Id { get; init; }
}
