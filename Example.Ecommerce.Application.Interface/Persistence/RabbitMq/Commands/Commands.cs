using Example.Ecommerce.Application.Interface.Persistence.RabbitMq.Events;
using Example.Ecommerce.Transversal.Common.Extension;

namespace Example.Ecommerce.Application.Interface.Persistence.RabbitMq.Commands;

public abstract class Command : Message
{
    public DateTime Timestamp { get; protected set; }

    protected Command() => Timestamp = DateTime.Now.DateTimeZoneInfo();
}