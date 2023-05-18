using System.Text.Json.Serialization;

namespace Example.Ecommerce.Domain.Entities.ExternalServices
{
    public abstract class GoRestPostAbstractDto
    {
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("body")]
        public string? Body { get; set; }
    }

    public class GoRestGetPostData : GoRestPostAbstractDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }

    public class GoRestPostPostData : GoRestPostAbstractDto { }
}
