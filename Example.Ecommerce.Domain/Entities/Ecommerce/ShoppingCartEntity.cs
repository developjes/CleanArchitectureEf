using Example.Ecommerce.Domain.Entities.Common;

namespace Example.Ecommerce.Domain.Entities.Ecommerce;

public class ShoppingCartEntity : BaseDomainEntity
{
    #region Fields Prop

    public Guid? ShoppingCartMasterId { get; set; }

    #endregion Fields Prop

    #region Navigation Props

    public virtual ICollection<ShoppingCartItemEntity>? ShoppingCartItems { get; set; }

    #endregion Navigation props
}