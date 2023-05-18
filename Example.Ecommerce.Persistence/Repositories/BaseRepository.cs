using Example.Ecommerce.Application.Interface.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace Example.Ecommerce.Persistence.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        internal readonly DbContext _dbcontext;
        internal readonly DbSet<TEntity> _dbSet;

        public BaseRepository(DbContext dbcontext) => (_dbcontext, _dbSet) = (dbcontext, dbcontext.Set<TEntity>());
        public IQueryable<TEntity> AsQuery() => _dbSet.AsQueryable<TEntity>().AsNoTracking();

        public IQueryable<TEntity> AsQuery(
            bool asTracking,
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            int? top = null,
            int? skip = null,
            Expression<Func<TEntity, object>>[] includeProperties = default!
        ) {
            IQueryable<TEntity> query = _dbSet.AsQueryable<TEntity>();

            if (filter is not null) query = query.Where(filter);

            includeProperties?.ToList().ForEach(include => query = query.Include(include));

            if (orderBy is not null) query = orderBy(query);

            if (skip.HasValue) query = query.Skip(skip.Value);

            if (top.HasValue) query = query.Take(top.Value);

            if(asTracking) query = query.AsTracking();

            return query;
        }

        #region Get methods data

        public virtual async Task<IEnumerable<TEntity>> Get(
            bool asTracking = true,
            Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            int? top = null,
            int? skip = null,
            Expression<Func<TEntity, object>>[] includeProperties = default!,
            CancellationToken cancellationToken = default
        ) => await AsQuery(asTracking, filter, orderBy, top, skip, includeProperties).ToListAsync(cancellationToken);

        public virtual async Task<int> Count(
            bool asTracking,
            Expression<Func<TEntity, bool>>? filter = null,
            CancellationToken cancellationToken = default
        ) => await AsQuery(asTracking: asTracking, filter: filter).CountAsync(cancellationToken);

        public virtual async Task<TEntity?> GetFirst(
            bool asTracking = true,
            Expression<Func<TEntity, bool>>? filter = null,
            int? top = null,
            int? skip = null,
            Expression<Func<TEntity, object>>[] includeProperties = default!,
            CancellationToken cancellationToken = default
        ) => await AsQuery(asTracking: asTracking, filter: filter, includeProperties: includeProperties)
                .FirstOrDefaultAsync(cancellationToken);

        public virtual async Task<TEntity?> GetLast(
            bool asTracking = true,
            Expression<Func<TEntity, bool>>? filter = null,
            int? top = null,
            int? skip = null,
            Expression<Func<TEntity, object>>[] includeProperties = default!,
            CancellationToken cancellationToken = default
        ) => await AsQuery(asTracking: asTracking, filter: filter, includeProperties: includeProperties)
            .LastOrDefaultAsync(cancellationToken);

        #endregion

        public virtual async Task Insert(TEntity tEntity) => await _dbcontext.AddAsync(tEntity);

        public virtual async Task Insert(IEnumerable<TEntity> tEntities) => await _dbcontext.AddRangeAsync(tEntities);

        public async virtual Task<TEntity> Patch(object entityId, object updateObject)
        {
            if (entityId is null)
                throw new ArgumentNullException(nameof(entityId), $"{nameof(entityId)} cannot be null.");

            if (updateObject is null)
                throw new ArgumentNullException(nameof(entityId), $"{nameof(entityId)} cannot be null.");

            TEntity? tEntity = await _dbSet.FindAsync(entityId);

            if (tEntity is null) throw new DbUpdateConcurrencyException(nameof(tEntity));

            foreach (PropertyInfo? dbProperty in
                tEntity!.GetType().GetProperties().Where(p => !p.GetGetMethod()!.GetParameters().Any()))
            {
                PropertyInfo? propertyNameNewTentity =
                    Array.Find(updateObject.GetType().GetProperties(), pp => pp.Name.Equals(dbProperty.Name));

                if (propertyNameNewTentity is not null && propertyNameNewTentity.GetType().Name.Equals(dbProperty.GetType().Name))
                    dbProperty.SetValue(tEntity, propertyNameNewTentity.GetValue(updateObject, null));
            }

            return tEntity;
        }

        public async virtual Task<TEntity> Patch(TEntity? tEntity, object updateObject)
        {
            if (tEntity is not null)
                throw new ArgumentNullException(nameof(tEntity), $"{nameof(tEntity)} cannot be null.");

            if (updateObject is null)
                throw new ArgumentNullException(nameof(tEntity), $"{nameof(tEntity)} cannot be null.");

            _dbSet.Attach(tEntity!);

            if (tEntity is null) throw new DbUpdateConcurrencyException(nameof(tEntity));

            foreach (PropertyInfo? dbProperty in
                tEntity!.GetType().GetProperties().Where(p => !p.GetGetMethod()!.GetParameters().Any()))
            {
                PropertyInfo? propertyNameNewTentity =
                    Array.Find(updateObject.GetType().GetProperties(), pp => pp.Name.Equals(dbProperty.Name));

                if (propertyNameNewTentity is not null && propertyNameNewTentity.GetType().Name.Equals(dbProperty.GetType().Name))
                    dbProperty.SetValue(tEntity, propertyNameNewTentity.GetValue(updateObject, null));
            }

            return tEntity;
        }

        public virtual void Update(TEntity tEntity) => _dbcontext.Update(tEntity);

        public virtual void Update(IEnumerable<TEntity> tEntitites) => _dbcontext.UpdateRange(tEntitites);

        public virtual void Delete(object id) { TEntity? tEntity = _dbSet.Find(id); Delete(tEntity); }

        private void Delete(TEntity? tEntity)
        {
            if (tEntity is null)
                throw new DbUpdateConcurrencyException(nameof(tEntity));

            if (_dbcontext.Entry(tEntity).State.Equals(EntityState.Detached))
                _dbSet.Attach(tEntity);

            _dbSet.Remove(tEntity);
        }

        public void Delete(IEnumerable<TEntity> tEntities)
        {
            if (tEntities.Any(x => x is null))
                throw new DbUpdateConcurrencyException(nameof(tEntities));

            foreach (TEntity tEntity in tEntities)
            {
                if (_dbcontext.Entry(tEntity).State.Equals(EntityState.Detached))
                    _dbSet.Attach(tEntity);

                _dbSet.Remove(tEntity);
            }
        }
    }
}