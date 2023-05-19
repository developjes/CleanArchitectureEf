using Example.Ecommerce.Application.Interface.Persistence.Connector.Ef;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace Example.Ecommerce.Persistence.Repositories.EfCore
{
    public sealed class EfBaseRepository<T> : IEfBaseRepository<T> where T : class
    {
        private readonly DbContext _dbcontext;
        private readonly DbSet<T> _dbSet;

        public EfBaseRepository(DbContext dbcontext) => (_dbcontext, _dbSet) = (dbcontext, dbcontext.Set<T>());
        public IQueryable<T> AsQuery() => _dbSet.AsQueryable<T>().AsNoTracking();

        public IQueryable<T> AsQuery(
            bool asTracking,
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            int? top = null,
            int? skip = null,
            Expression<Func<T, object>>[] includeProperties = default!
        )
        {
            IQueryable<T> query = _dbSet.AsQueryable<T>();

            if (filter is not null) query = query.Where(filter);

            if (orderBy is not null) query = includeProperties.Aggregate(query, (current, include) => current.Include(include));

            if (orderBy is not null) query = orderBy(query);

            if (skip.HasValue) query = query.Skip(skip.Value);

            if (top.HasValue) query = query.Take(top.Value);

            if (asTracking) query = query.AsTracking();

            return query;
        }

        #region Get methods data

        public async Task<IReadOnlyList<T>> Get(
            bool asTracking = true,
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            int? top = null,
            int? skip = null,
            Expression<Func<T, object>>[] includeProperties = default!,
            CancellationToken cancellationToken = default
        ) => await AsQuery(asTracking, filter, orderBy, top, skip, includeProperties).ToListAsync(cancellationToken);

        public async Task<int> Count(
            bool asTracking,
            Expression<Func<T, bool>>? filter = null,
            CancellationToken cancellationToken = default
        ) => await AsQuery(asTracking: asTracking, filter: filter).CountAsync(cancellationToken);

        public async Task<T?> GetFirst(
            bool asTracking = true,
            Expression<Func<T, bool>>? filter = null,
            int? top = null,
            int? skip = null,
            Expression<Func<T, object>>[] includeProperties = default!,
            CancellationToken cancellationToken = default
        ) => await AsQuery(asTracking: asTracking, filter: filter, includeProperties: includeProperties)
                .FirstOrDefaultAsync(cancellationToken);

        public async Task<T?> GetLast(
            bool asTracking = true,
            Expression<Func<T, bool>>? filter = null,
            int? top = null,
            int? skip = null,
            Expression<Func<T, object>>[] includeProperties = default!,
            CancellationToken cancellationToken = default
        ) => await AsQuery(asTracking: asTracking, filter: filter, includeProperties: includeProperties)
            .LastOrDefaultAsync(cancellationToken);

        #endregion

        public async Task Insert(T tEntity) => await _dbcontext.AddAsync(tEntity);

        public async Task Insert(IEnumerable<T> tEntities) => await _dbcontext.AddRangeAsync(tEntities);

        public async Task<T> Patch(object entityId, object updateObject)
        {
            if (entityId is null)
                throw new ArgumentNullException(nameof(entityId), $"{nameof(entityId)} cannot be null.");

            if (updateObject is null)
                throw new ArgumentNullException(nameof(entityId), $"{nameof(entityId)} cannot be null.");

            T? tEntity = await _dbSet.FindAsync(entityId);

            if (tEntity is null) throw new DbUpdateConcurrencyException(nameof(tEntity));

            foreach (PropertyInfo? dbProperty in
                tEntity!.GetType().GetProperties().Where(p => !p.GetGetMethod()!.GetParameters().Any()))
            {
                PropertyInfo? propertyNameNewTentity =
                    Array.Find(updateObject.GetType().GetProperties(), pp => pp.Name.Equals(dbProperty.Name));

                if (propertyNameNewTentity?.GetType().Name.Equals(dbProperty.GetType().Name) == true)
                    dbProperty.SetValue(tEntity, propertyNameNewTentity.GetValue(updateObject, null));
            }

            return tEntity;
        }

        public T Patch(T? tEntity, object updateObject)
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

                if (propertyNameNewTentity?.GetType().Name.Equals(dbProperty.GetType().Name) is true)
                    dbProperty.SetValue(tEntity, propertyNameNewTentity.GetValue(updateObject, null));
            }

            return tEntity;
        }

        public void Update(T tEntity) => _dbcontext.Update(tEntity);

        public void Update(IEnumerable<T> tEntitites) => _dbcontext.UpdateRange(tEntitites);

        public void Delete(object id) { T? tEntity = _dbSet.Find(id); Delete(tEntity); }

        private void Delete(T? tEntity)
        {
            if (tEntity is null)
                throw new DbUpdateConcurrencyException(nameof(tEntity));

            if (_dbcontext.Entry(tEntity).State.Equals(EntityState.Detached))
                _dbSet.Attach(tEntity);

            _dbSet.Remove(tEntity);
        }

        public void Delete(IEnumerable<T> tEntities)
        {
            if (tEntities.Any(x => x is null)) throw new DbUpdateConcurrencyException(nameof(tEntities));

            foreach (T tEntity in tEntities)
            {
                if (_dbcontext.Entry(tEntity).State.Equals(EntityState.Detached)) _dbSet.Attach(tEntity);

                _dbSet.Remove(tEntity);
            }
        }
    }
}