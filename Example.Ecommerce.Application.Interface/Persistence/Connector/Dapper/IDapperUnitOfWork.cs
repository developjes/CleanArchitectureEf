namespace Example.Ecommerce.Application.Interface.Persistence.Connector.Dapper
{
    public interface IDapperUnitOfWork : IDisposable
    {
        IDapperBaseRepository<T> DapperRepository<T>() where T : class;
    }
}
