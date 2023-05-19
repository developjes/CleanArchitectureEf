using Example.Ecommerce.Application.Interface.Persistence.Connector.Ef;
using Example.Ecommerce.Domain.Entities.Parametrization;

namespace Example.Ecommerce.Application.Interface.Persistence.Parametrization
{
    public interface IStateRepository : IEfBaseRepository<StateEntity> { }
}