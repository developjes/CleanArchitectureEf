namespace Example.Ecommerce.Application.Interface.Persistence.Connector.Dapper
{
    public interface IDapperBaseRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IReadOnlyList<T>> GetAll();
        Task Insert(T entity);
        Task Update(T entity);
        Task<bool> Delete(T entity);
        Task Insert(IEnumerable<T> entity);
        Task Update(IEnumerable<T> entity);
    }
}
