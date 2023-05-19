using Example.Ecommerce.Domain.Entities.Common;
using Example.Ecommerce.Domain.Entities.Ecommerce;

namespace Example.Ecommerce.Domain.Entities.Parametrization;

public sealed class StateEntity : BaseDomainEntity
{
    #region Fields Prop

    public string? Name { get; set; }
    public string? Description { get; set; }

    #endregion Fields Prop

    #region Navigation props

    public ICollection<ProductEntity>? Products { get; set; }

    #endregion Navigation props
}