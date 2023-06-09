﻿using System.Linq.Expressions;

namespace Example.Ecommerce.Application.Interface.Persistence.Connector.Ef;

public interface IEfBaseRepository<T> where T : class
{
    #region Queries action

    IQueryable<T> AsQuery();

    IQueryable<T> AsQuery(
        bool asTracking,
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        int? top = null,
        int? skip = null,
        List<Expression<Func<T, object>>>? includeProperties = default!
    );

    Task<IReadOnlyList<T>> Get(
        bool asTracking = true,
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        int? top = null,
        int? skip = null,
        List<Expression<Func<T, object>>>? includeProperties = default!,
        CancellationToken cancellationToken = default
    );

    Task<int> Count(
        bool asTracking,
        Expression<Func<T, bool>>? filter = null,
        CancellationToken cancellationToken = default
    );

    Task<T?> GetFirst(
        bool asTracking = true,
        Expression<Func<T, bool>>? filter = null,
        List<Expression<Func<T, object>>>? includeProperties = default!,
        CancellationToken cancellationToken = default
    );

    Task<T?> GetLast(
        bool asTracking = true,
        Expression<Func<T, bool>>? filter = null,
        List<Expression<Func<T, object>>>? includeProperties = default!,
        CancellationToken cancellationToken = default
    );

    Task Insert(T tEntity);

    Task Insert(IEnumerable<T> tEntities);

    void Patch<E>(E objSrcChanges, T entityToUpdate) where E : class;

    void Update(T tEntity);

    void Update(IEnumerable<T> tEntitites);

    void Delete(int id);

    void Delete(T? tEntity);

    void Delete(IEnumerable<T> tEntities);

    #endregion

    #region Specification

    Task<T> GetByIdWithSpec(ISpecification<T> spec);

    Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> spec);

    Task<int> CountAsync(ISpecification<T> spec);

    #endregion Specification
}