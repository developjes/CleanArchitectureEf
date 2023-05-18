using Example.Ecommerce.Domain.Entities.Common;
using Example.Ecommerce.Domain.Entities.Petition;

namespace Example.Ecommerce.Domain.Entities.Parametrization
{
    public class StateEntity : KeyIntegerTypeEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<PetitionEntity>? Petitions { get; set; }
    }
}