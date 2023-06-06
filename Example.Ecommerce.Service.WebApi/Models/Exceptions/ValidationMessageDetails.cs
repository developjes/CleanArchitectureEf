namespace Example.Ecommerce.Service.WebApi.Models.Exceptions;

public class ValidationMessageDetails
{
    public IEnumerable<IDictionary<string, string>>? Messages { get; set; }
    public int Status { get; set; }
    public string? Title { get; set; }
    public string? Type { get; set; }
}