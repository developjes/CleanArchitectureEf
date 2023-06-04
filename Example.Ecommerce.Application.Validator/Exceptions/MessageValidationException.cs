namespace Example.Ecommerce.Application.Validator.Exceptions;

public class MessageValidationException : Exception
{
    public List<Dictionary<string, string>> Messages { get; }

    public MessageValidationException(string message) : base(message) =>
        Messages = new List<Dictionary<string, string>>();

    public MessageValidationException(string message, Exception innerException) : base(message, innerException) =>
        Messages = new List<Dictionary<string, string>>();

    public MessageValidationException() : base("One or more validation message have occurred") =>
        Messages = new List<Dictionary<string, string>>();

    public MessageValidationException(IDictionary<string, string> messages) : this()
    {
        Messages = new List<Dictionary<string, string>>();

        foreach (KeyValuePair<string, string> message in messages)
            Messages.Add(new Dictionary<string, string> { { message.Key, message.Value } });
    }
}