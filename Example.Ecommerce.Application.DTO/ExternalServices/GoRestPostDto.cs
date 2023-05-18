using System.Text.Json.Serialization;

namespace Example.Ecommerce.Application.DTO.ExternalServices
{
    public abstract class GoRestPostAbstract
    {
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("body")]
        public string? Body { get; set; }
    }

    public class GoRestGetPostDto : GoRestPostAbstract
    {
        public int Id { get; set; }
    }

    public class GoRestCreatePostDto : GoRestPostAbstract { }
}
