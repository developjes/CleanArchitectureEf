using Example.Ecommerce.Domain.Entities.Common;
using Example.Ecommerce.Domain.Persistence;
using Microsoft.EntityFrameworkCore.Storage;

namespace Example.Ecommerce.Application.Interface.Persistence.Connector.Ef;

public interface IEfUnitOfWork : IAsyncDisposable
{
    IEfBaseRepository<T> EfRepository<T>() where T : BaseDomainEntity;

    Task<int> EfSave(CancellationToken cancellationToken = default);
    void EfRejectChanges();
    Task<IReadOnlyList<T>> EfExecuteEnumerableSP<T>(string spName, List<SqlParam> parameters);
    Task<IDbContextTransaction> EfBeginTransactionAsync();
    Task EfCommitAsync(IDbContextTransaction transaction);
    Task EfRollbackAsync(IDbContextTransaction transaction);
}