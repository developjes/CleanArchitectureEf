using Example.Ecommerce.Application.Interface.Persistence.RabbitMq;
using Example.Ecommerce.Application.Interface.Persistence.RabbitMq.Commands;
using Example.Ecommerce.Application.Interface.Persistence.RabbitMq.Events;
using Example.Ecommerce.Persistence.Models.Configuration;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Example.Ecommerce.Persistence.EventBus;

public class EventBusRabbitMQ : IEventBus
{
    private readonly RabbitMqSettings _rabbitMQSettings;
    private readonly IMediator _mediator;
    private readonly Dictionary<string, List<Type>> _handlers;
    private readonly List<Type> _eventTypes;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public EventBusRabbitMQ(
        IMediator mediator,
        IServiceScopeFactory serviceScopeFactory,
        IOptions<RabbitMqSettings> rabbitMQSettings
    )
    {
        _mediator = mediator;
        _serviceScopeFactory = serviceScopeFactory;
        _rabbitMQSettings = rabbitMQSettings.Value;
        _handlers = new Dictionary<string, List<Type>>();
        _eventTypes = new List<Type>();
    }

    public void Publish<T>(T @event) where T : Event
    {
        ConnectionFactory factory = new()
        {
            HostName = _rabbitMQSettings.HostName,
            UserName = _rabbitMQSettings.UserName,
            Password = _rabbitMQSettings.Password,
            VirtualHost = _rabbitMQSettings.VirtualHost
        };

        using IConnection connection = factory.CreateConnection();
        using IModel channel = connection.CreateModel();

        string eventName = @event.GetType().Name;
        channel.QueueDeclare(eventName, false, false, false, null);

        string message = JsonSerializer.Serialize(@event);

        byte[] body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(string.Empty, eventName, null, body);
    }

    public Task SendCommand<T>(T command) where T : Command => _mediator.Send(command);

    public void Subscribe<T, TH>() where T : Event where TH : IEventHandler<T>
    {
        string eventName = typeof(T).Name;
        Type handlerType = typeof(TH);

        if (!_eventTypes.Contains(typeof(T)))
            _eventTypes.Add(typeof(T));

        if (!_handlers.ContainsKey(eventName))
            _handlers.Add(eventName, new List<Type>());

        if (_handlers[eventName].Any(s => s.GetType() == handlerType))
            throw new ArgumentException($"El handler exception {handlerType.Name} ya fue registrado anteriormente por '{eventName}'", nameof(handlerType));

        _handlers[eventName].Add(handlerType);

        StartBasicConsume<T>();
    }

    private void StartBasicConsume<T>() where T : Event
    {
        ConnectionFactory factory = new()
        {
            HostName = _rabbitMQSettings.HostName,
            UserName = _rabbitMQSettings.UserName,
            Password = _rabbitMQSettings.Password,
            VirtualHost = _rabbitMQSettings.VirtualHost
        };

        IConnection connection = factory.CreateConnection();
        IModel channel = connection.CreateModel();

        string eventName = typeof(T).Name;

        channel.QueueDeclare(eventName, false, false, false, null);

        AsyncEventingBasicConsumer consumer = new(channel);

        consumer.Received += Consumer_Received;

        channel.BasicConsume(eventName, true, consumer);
    }

    private async Task Consumer_Received(object sender, BasicDeliverEventArgs e)
    {
        string eventName = e.RoutingKey;
        string message = Encoding.UTF8.GetString(e.Body.Span);

        try { await ProcessEvent(eventName, message).ConfigureAwait(false); }
        catch (Exception ex)
        {

        }
    }

    private async Task ProcessEvent(string eventName, string message)
    {
        if (_handlers.ContainsKey(eventName))
        {
            using IServiceScope scope = _serviceScopeFactory.CreateScope();

            foreach (Type subscription in _handlers[eventName])
            {
                object? handler = scope.ServiceProvider.GetService(subscription);

                if (handler is null) continue;

                Type? eventType = _eventTypes.SingleOrDefault(t => t.Name == eventName);
                object? @event = JsonConvert.DeserializeObject(message, eventType!);
                Type concreteType = typeof(IEventHandler<>).MakeGenericType(eventType);

                await (Task)concreteType.GetMethod("Handle")!.Invoke(handler, new object[] { @event! })!;
            }
        }
    }
}