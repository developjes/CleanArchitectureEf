using Example.Ecommerce.Domain.Entities.Common;
using Example.Ecommerce.Domain.Entities.Parametrization;

namespace Example.Ecommerce.Domain.Entities.Petition
{
    public class BeneficiaryEntity : KeyIntegerTypeEntity
    {
        public string? IdentificationNumber { get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? FirstLastName { get; set; }
        public string? SecondLastName { get; set; }

        public int IdentificationTypeId { get; set; }
        public int HeadLineId { get; set; }

        public virtual IdentificationTypeEntity? IdentificationType { get; set; }
        public virtual HeadLineEntity? HeadLine { get; set; }
    }
}
