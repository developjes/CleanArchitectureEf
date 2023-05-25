using Example.Ecommerce.Application.Interface.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Example.Ecommerce.Persistence.Specification;

public static class SpecificationEvaluator<T> where T : class
{
    public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
    {
        if (spec.Criteria is not null)
            inputQuery = inputQuery.Where(spec.Criteria);

        if (spec.OrderBy is not null)
            inputQuery = inputQuery.OrderBy(spec.OrderBy);

        if (spec.OrderByDescending is not null)
            inputQuery = inputQuery.OrderBy(spec.OrderByDescending);

        if (spec.IsPagingEnable)
            inputQuery = inputQuery.Skip(spec.Skip).Take(spec.Take);

        return spec.Includes!
            .Aggregate(inputQuery, (current, include) => current.Include(include)).AsSplitQuery();
    }
}