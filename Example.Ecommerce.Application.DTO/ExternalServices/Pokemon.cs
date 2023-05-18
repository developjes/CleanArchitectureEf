namespace Example.Ecommerce.Application.DTO.ExternalServices
{
    public class PokemonServiceDto
    {
        public int Count { get; set; }
        public string? Next { get; set; }
        public string? Previous { get; set; }
        public IEnumerable<Pokemon>? Results { get; set; }
    }

    public class Pokemon
    {
        public string? Name { get; set; }
        public string? Url { get; set; }
    }
}