using Domain.Events;

namespace Application.Ports.Adapters
{
    public interface IEventPublisherPort
    {
        Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : DomainEvent;
        Task PublishBatchAsync(IEnumerable<DomainEvent> events, CancellationToken cancellationToken = default);
    }
}
