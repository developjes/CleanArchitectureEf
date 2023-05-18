using Example.Ecommerce.Application.DTO.Petition.Response;

namespace Example.Ecommerce.Application.DTO.Parametrization.Response
{
    public class StateWithPetitionsDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int CountPetitions { get; set; }
        public ICollection<PetitionDto>? Petitions { get; set; }
    }
}