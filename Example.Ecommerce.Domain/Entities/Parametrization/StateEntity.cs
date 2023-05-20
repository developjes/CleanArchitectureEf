using Example.Ecommerce.Domain.Entities.Common;
using Example.Ecommerce.Domain.Entities.Ecommerce;

namespace Example.Ecommerce.Domain.Entities.Parametrization;

public class StateEntity : BaseDomainEntity
{
    #region Fields Prop

    public string? Name { get; set; }
    public string? Description { get; set; }

    #endregion Fields Prop

    #region Navigation props

    public virtual ICollection<ProductEntity>? Products { get; set; }
    public virtual ICollection<OrderEntity>? Orders { get; set; }

    #endregion Navigation props
}