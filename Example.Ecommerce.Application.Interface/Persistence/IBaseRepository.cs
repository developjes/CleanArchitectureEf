using System.Linq.Expressions;

namespace Example.Ecommerce.Application.Interface.Persistence
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        #region Queries action

        IQueryable<TEntity> AsQuery();

        IQueryable<TEntity> AsQuery(
            bool asTracking,
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            int? top = null,
            int? skip = null,
            Expression<Func<TEntity, object>>[] includeProperties = default!
        );

        Task<IEnumerable<TEntity>> Get(
            bool asTracking = true,
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            int? top = null,
            int? skip = null,
            Expression<Func<TEntity, object>>[] includeProperties = default!,
            CancellationToken cancellationToken = default
        );

        Task<int> Count(
            bool asTracking,
            Expression<Func<TEntity, bool>>? filter = null,
            CancellationToken cancellationToken = default
        );

        Task<TEntity?> GetFirst(
            bool asTracking = true,
            Expression<Func<TEntity, bool>>? filter = null,
            int? top = null,
            int? skip = null,
            Expression<Func<TEntity, object>>[] includeProperties = default!,
            CancellationToken cancellationToken = default
        );

        Task<TEntity?> GetLast(
            bool asTracking = true,
            Expression<Func<TEntity, bool>>? filter = null,
            int? top = null,
            int? skip = null,
            Expression<Func<TEntity, object>>[] includeProperties = default!,
            CancellationToken cancellationToken = default
        );

        Task Insert(TEntity tEntity);

        Task Insert(IEnumerable<TEntity> tEntities);

        Task<TEntity> Patch(object entityId, object updateObject);

        Task<TEntity> Patch(TEntity? tEntity, object updateObject);

        void Update(TEntity tEntity);

        void Update(IEnumerable<TEntity> tEntitites);

        void Delete(object id);

        void Delete(IEnumerable<TEntity> tEntities);

        #endregion
    }
}