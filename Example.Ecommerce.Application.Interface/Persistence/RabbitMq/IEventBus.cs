using Example.Ecommerce.Application.Interface.Persistence.RabbitMq.Commands;
using Example.Ecommerce.Application.Interface.Persistence.RabbitMq.Events;

namespace Example.Ecommerce.Application.Interface.Persistence.RabbitMq;

public interface IEventBus
{
    Task SendCommand<T>(T command) where T : Command;

    void Publish<T>(T @event) where T : Event;

    void Subscribe<T, TH>() where T : Event where TH : IEventHandler<T>;
}
