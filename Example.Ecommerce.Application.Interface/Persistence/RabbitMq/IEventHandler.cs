using Example.Ecommerce.Application.Interface.Persistence.RabbitMq.Events;

namespace Example.Ecommerce.Application.Interface.Persistence.RabbitMq;

public interface IEventHandler<in TEvent> : IEventHandler where TEvent : Event
{
    Task Handle(TEvent @event);
}

public interface IEventHandler { }