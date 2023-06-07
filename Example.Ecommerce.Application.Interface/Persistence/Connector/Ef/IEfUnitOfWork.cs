using Example.Ecommerce.Domain.Entities.Common;
using Example.Ecommerce.Domain.Persistence;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace Example.Ecommerce.Application.Interface.Persistence.Connector.Ef;

public interface IEfUnitOfWork : IAsyncDisposable
{
    Task LoadRelatedData<T, TProperty>(T entity, Expression<Func<T, TProperty?>> reference)
        where T : BaseDomainEntity where TProperty : BaseDomainEntity;
    IEfBaseRepository<T> EfRepository<T>() where T : BaseDomainEntity;

    Task<int> EfCommit(CancellationToken cancellationToken = default);
    void EfRejectChanges();
    Task<IReadOnlyList<T>> EfExecuteEnumerableSP<T>(string spName, List<SqlParam> parameters);
    Task<IDbContextTransaction> EfBeginTransactionAsync();
    Task EfCommitAsync(IDbContextTransaction transaction);
    Task EfRollbackAsync(IDbContextTransaction transaction);
}