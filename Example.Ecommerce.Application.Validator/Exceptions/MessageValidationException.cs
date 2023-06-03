namespace Example.Ecommerce.Application.Validator.Exceptions;

public class MessageValidationException : Exception
{
    public IDictionary<string, string[]> Messages { get; }

    public MessageValidationException(string message) : base(message) =>
        Messages = new Dictionary<string, string[]>();

    public MessageValidationException(string message, Exception innerException) : base(message, innerException) =>
        Messages = new Dictionary<string, string[]>();

    public MessageValidationException() : base("One or more validation message have occurred.") =>
        Messages = new Dictionary<string, string[]>();

    public MessageValidationException(IDictionary<string, string> messages) : this()
    {
        Messages = messages
            .GroupBy(e => e.Key, e => e.Value)
            .ToDictionary(messageGroup => messageGroup.Key, messageGroup => messageGroup.ToArray());
    }
}