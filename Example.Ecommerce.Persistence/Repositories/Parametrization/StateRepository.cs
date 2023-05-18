using Example.Ecommerce.Application.Interface.Persistence.Parametrization;
using Example.Ecommerce.Domain.Entities.Parametrization;
using Example.Ecommerce.Persistence.Contexts.Mysql;
using Example.Ecommerce.Persistence.Contexts.SqlServer;

namespace Example.Ecommerce.Persistence.Repositories.Parametrization
{
    public class StateRepository : BaseRepository<StateEntity>, IStateRepository
    {
        public StateRepository(MysqlApplicationDbContext context) : base(context) { }
    }
}