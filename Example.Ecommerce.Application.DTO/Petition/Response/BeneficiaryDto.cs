using Example.Ecommerce.Application.DTO.Parametrization.Response;

namespace Example.Ecommerce.Application.DTO.Petition.Response
{
    public class BeneficiaryDto
    {
        public int Id { get; set; }
        public string? IdentificationNumber { get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? FirstLastName { get; set; }
        public string? SecondLastName { get; set; }

        public int IdentificationTypeId { get; set; }

        public virtual IdentificationTypeDto? IdentificationType { get; set; }
    }
}
