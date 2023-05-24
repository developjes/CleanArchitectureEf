namespace Example.Ecommerce.Domain.ExternalServices.EmailSendGrid;

public class EmailDataRequest
{
    public string? To { get; set; }
    public string? Subject { get; set; }
    public string? Body { get; set; }
}