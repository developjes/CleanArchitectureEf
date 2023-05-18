using Example.Ecommerce.Application.DTO.Common;
using Example.Ecommerce.Application.Interface.Persistence.Parametrization;
using Example.Ecommerce.Application.Interface.Persistence.Petition;
using Microsoft.EntityFrameworkCore.Storage;

namespace Example.Ecommerce.Application.Interface.Persistence
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IStateRepository StateRepository { get; }
        IIdentificationTypeRepository IdentificationTypeRepository { get; }

        IPetitionRepository PetitionRepository { get; }
        IHeadLineRepository HeadLineRepository { get; }
        IBeneficiaryRepository BeneficiaryRepository { get; }

        Task<int> Save(CancellationToken cancellationToken = default);
        void RejectChanges();
        Task<IEnumerable<T>> ExecuteEnumerableSP<T>(string spName, List<SqlParam> parameters);
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task CommitAsync(IDbContextTransaction transaction);
        Task RollbackAsync(IDbContextTransaction transaction);
    }
}