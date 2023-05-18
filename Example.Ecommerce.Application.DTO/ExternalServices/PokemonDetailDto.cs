namespace Example.Ecommerce.Application.DTO.ExternalServices
{
    public class PokemonDetailDto
    {
        public int BaseExperience { get; set; }
        public SpriteDto? Sprites { get; set; }
    }

    public class SpriteDto
    {
        public string? BackDefault { get; set; }
        public OtherDto? Other { get; set; }
    }

    public class OtherDto
    {
        public OfficialArtWorkDto? OfficialArtwork { get; set; }
    }

    public class OfficialArtWorkDto
    {
        public string? FrontDefault { get; set; }
        public string? FrontShiny { get; set; }
    }
}