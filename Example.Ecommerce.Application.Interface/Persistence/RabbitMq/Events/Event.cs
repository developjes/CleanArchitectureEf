using Example.Ecommerce.Transversal.Common.Extension;

namespace Example.Ecommerce.Application.Interface.Persistence.RabbitMq.Events;

public abstract class Event
{
    public DateTime Timestamp { get; protected set; }

    protected Event() => Timestamp = DateTime.Now.DateTimeZoneInfo();
}