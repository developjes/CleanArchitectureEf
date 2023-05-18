using System.Text.Json.Serialization;

namespace Example.Ecommerce.Domain.Entities.ExternalServices
{
    public class PokemonDetailData
    {
        [JsonPropertyName("base_experience")]
        public int BaseExperience { get; set; }
        public SpriteData? Sprites { get; set; }
    }

    public class SpriteData
    {
        [JsonPropertyName("back_default")]
        public string? BackDefault { get; set; }
        public OtherData? Other { get; set; }
    }

    public class OtherData
    {
        [JsonPropertyName("official-artwork")]
        public OfficialArtWorkData? OfficialArtwork { get; set; }
    }

    public class OfficialArtWorkData
    {
        [JsonPropertyName("front_default")]
        public string? FrontDefault { get; set; }

        [JsonPropertyName("front_shiny")]
        public string? FrontShiny { get; set; }
    }
}