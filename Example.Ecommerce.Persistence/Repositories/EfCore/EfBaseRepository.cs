using AutoMapper;
using Example.Ecommerce.Application.Interface.Persistence;
using Example.Ecommerce.Application.Interface.Persistence.Connector.Ef;
using Example.Ecommerce.Domain.Entities.Common;
using Example.Ecommerce.Persistence.Specification;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Example.Ecommerce.Persistence.Repositories.EfCore;

public sealed class EfBaseRepository<T> : IEfBaseRepository<T> where T : BaseDomainEntity
{
    private readonly DbContext _dbcontext;
    private readonly DbSet<T> _dbSet;
    private readonly IMapper _mapper;

    public EfBaseRepository(DbContext dbcontext, IMapper mapper) =>
        (_dbcontext, _dbSet, _mapper) = (dbcontext, dbcontext.Set<T>(), mapper);

    public IQueryable<T> AsQuery() => _dbSet.AsQueryable<T>().AsNoTracking();

    public IQueryable<T> AsQuery(
        bool asTracking,
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        int? top = null,
        int? skip = null,
        List<Expression<Func<T, object>>>? includeProperties = default!
    )
    {
        IQueryable<T> query = _dbSet.AsQueryable<T>();

        if (filter is not null) query = query.Where(filter);

        if (orderBy is not null) query = includeProperties!.Aggregate(query, (current, include) => current.Include(include));

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
        List<Expression<Func<T, object>>>? includeProperties = default!,
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
        List<Expression<Func<T, object>>>? includeProperties = default!,
        CancellationToken cancellationToken = default
    ) => await AsQuery(asTracking: asTracking, filter: filter, includeProperties: includeProperties)
        .FirstOrDefaultAsync(cancellationToken);

    public async Task<T?> GetLast(
        bool asTracking = true,
        Expression<Func<T, bool>>? filter = null,
        List<Expression<Func<T, object>>>? includeProperties = default!,
        CancellationToken cancellationToken = default
    ) => await AsQuery(asTracking: asTracking, filter: filter, includeProperties: includeProperties)
        .LastOrDefaultAsync(cancellationToken);

    #endregion Get methods data

    #region Insert Data

    public async Task Insert(T tEntity) => await _dbcontext.AddAsync(tEntity);

    public async Task Insert(IEnumerable<T> tEntities) => await _dbcontext.AddRangeAsync(tEntities);

    #endregion Insert Data

    #region Update Data

    public void Patch(T? entityToUpdate, object objSrcChanges)
    {
        if (entityToUpdate is null || objSrcChanges is null)
            throw new ArgumentNullException(nameof(entityToUpdate), $"{nameof(entityToUpdate)} cannot be null.");

        _dbSet.Attach(entityToUpdate!);

        _mapper.Map(objSrcChanges, entityToUpdate, typeof(object), typeof(T));
    }

    public void Update(T tEntity)
    {
        if (_dbcontext.Entry(tEntity).State.Equals(EntityState.Detached))
            _dbSet.Attach(tEntity);

        _dbcontext.Update(tEntity);
    }

    public void Update(IEnumerable<T> tEntitites) => _dbcontext.UpdateRange(tEntitites);

    #endregion Update Data

    #region Hard Delete Data

    public void Delete(int id)
    {
        T? tEntity = _dbSet.Find(id);
        Delete(tEntity);
    }

    public void Delete(T? tEntity)
    {
        if (tEntity is null)
            throw new ArgumentException(null, nameof(tEntity));

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

    #endregion Hard Delete Data

    #region Specification

    public async Task<int> CountAsync(ISpecification<T> spec) => await ApplySpecification(spec).CountAsync();

    public async Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> spec) =>
        await ApplySpecification(spec).ToListAsync();

    public async Task<T> GetByIdWithSpec(ISpecification<T> spec) => (await ApplySpecification(spec).FirstOrDefaultAsync())!;

    private IQueryable<T> ApplySpecification(ISpecification<T> spec) =>
        SpecificationEvaluator<T>.GetQuery(_dbcontext.Set<T>().AsQueryable(), spec);

    #endregion Specification
}