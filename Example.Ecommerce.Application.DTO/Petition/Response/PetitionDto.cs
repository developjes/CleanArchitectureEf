using Example.Ecommerce.Application.DTO.Parametrization;

namespace Example.Ecommerce.Application.DTO.Petition.Response
{
    public class PetitionDto
    {
        public int Id { get; set; }
        public string? Radicate { get; set; }
        public bool Expired { get; set; }
    }
}