using Dapper.Contrib.Extensions;
using Example.Ecommerce.Application.Interface.Persistence.Connector.Dapper;
using System.Data;

namespace Example.Ecommerce.Persistence.Repositories.Dapper;

public class DapperBaseRepository<T> : IDapperBaseRepository<T> where T : class
{
    private IDbConnection Connection { get; }

    public DapperBaseRepository(IDbConnection connection) => Connection = connection;

    public async Task<T> GetById(int id) => await Connection.GetAsync<T>(id);

    public async Task<IReadOnlyList<T>> GetAll() => (IReadOnlyList<T>)await Connection.GetAllAsync<T>();

    public async Task Insert(T entity) => await Connection.InsertAsync(entity);

    public async Task Insert(IEnumerable<T> entity) => await Connection.InsertAsync(entity);

    public async Task Update(T entity) => await Connection.UpdateAsync(entity);

    public async Task Update(IEnumerable<T> entity) => await Connection.UpdateAsync(entity);

    public async Task<bool> Delete(T entity) => await Connection.DeleteAsync(entity);

    public async Task<bool> Delete(IEnumerable<T> entity) => await Connection.DeleteAsync(entity);
}