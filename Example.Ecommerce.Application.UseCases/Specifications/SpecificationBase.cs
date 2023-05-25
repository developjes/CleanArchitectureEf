using Example.Ecommerce.Application.Interface.Persistence;
using System.Linq.Expressions;

namespace Example.Ecommerce.Application.UseCases.Specifications;

public class SpecificationBase<T> : ISpecification<T>
{
    #region Attributes

    public Expression<Func<T, bool>>? Criteria { get; }
    public List<Expression<Func<T, object>>> Includes { get; }
    public Expression<Func<T, object>>? OrderBy { get; private set; }
    public Expression<Func<T, object>>? OrderByDescending { get; private set; }
    public int Take { get; private set; }
    public int Skip { get; private set; }
    public bool IsPagingEnable { get; private set; }

    #endregion Attributes

    public SpecificationBase() => Includes = new List<Expression<Func<T, object>>>();

    public SpecificationBase(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
        Includes = new List<Expression<Func<T, object>>>();
    }

    #region Methods

    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression) => OrderBy = orderByExpression;

    protected void AddOrderByDescending(Expression<Func<T, object>> orderByExpression) => OrderByDescending = orderByExpression;

    protected void AddInclude(Expression<Func<T, object>> includeExpression) => Includes.Add(includeExpression);

    protected void ApplyPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
        IsPagingEnable = true;
    }

    #endregion Methods
}