using Example.Ecommerce.Application.DTO.Parametrization.Response;
using System.Drawing;

namespace Example.Ecommerce.Application.DTO.Petition.Response
{
    public class HeadLineDto
    {
        public int Id { get; set; }
        public string? IdentificationNumber { get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? FirstLastName { get; set; }
        public string? SecondLastName { get; set; }
        public DateTime BirthDate { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string? FullName { get; set; }
        public byte AgeYearsRunning { get; set; }
        public byte AgeMonthsRunning { get; set; }
        public byte AgeDaysRunning { get; set; }

        public int IdentificationTypeId { get; set; }

        public virtual IdentificationTypeDto? IdentificationType { get; set; }
        public virtual ICollection<PetitionDto>? Petitions { get; set; }
        public virtual ICollection<BeneficiaryDto>? Beneficiaries { get; set; }
    }
}