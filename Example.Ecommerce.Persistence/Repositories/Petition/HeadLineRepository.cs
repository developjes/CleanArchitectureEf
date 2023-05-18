using Example.Ecommerce.Application.Interface.Persistence.Petition;
using Example.Ecommerce.Domain.Entities.Petition;
using Example.Ecommerce.Persistence.Contexts.Mysql;
using Example.Ecommerce.Persistence.Contexts.SqlServer;

namespace Example.Ecommerce.Persistence.Repositories.Petition
{
    public class HeadLineRepository : BaseRepository<HeadLineEntity>, IHeadLineRepository
    {
        public HeadLineRepository(MysqlApplicationDbContext context) : base(context) { }
    }
}
