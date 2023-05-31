namespace Example.Ecommerce.Persistence.Models.Configuration;

public class RabbitMqSettings
{
    public string? HostName { get; init; }
    public string? VirtualHost { get; init; }
    public string? UserName { get; init; }
    public string? Password { get; init; }
}