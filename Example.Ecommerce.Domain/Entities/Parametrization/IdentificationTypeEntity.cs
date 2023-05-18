using Example.Ecommerce.Domain.Entities.Common;
using Example.Ecommerce.Domain.Entities.Petition;

namespace Example.Ecommerce.Domain.Entities.Parametrization
{
    public class IdentificationTypeEntity : KeyIntegerTypeEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<HeadLineEntity>? HeadLines { get; set; }
        public virtual ICollection<BeneficiaryEntity>? Beneficiaries { get; set; }
    }
}