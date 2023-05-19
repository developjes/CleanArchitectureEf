using Example.Ecommerce.Application.Interface.Persistence.Connector.Ef;
using Example.Ecommerce.Domain.Entities.Petition;

namespace Example.Ecommerce.Application.Interface.Persistence.Petition
{
    public interface IPetitionRepository : IEfBaseRepository<PetitionEntity> { }
}
