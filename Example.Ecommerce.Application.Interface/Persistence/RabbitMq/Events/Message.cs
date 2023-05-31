using MediatR;

namespace Example.Ecommerce.Application.Interface.Persistence.RabbitMq.Events;

public abstract class Message : IRequest<bool>
{
    public string MessageType { get; protected set; }

    protected Message() => MessageType = GetType().Name;
}