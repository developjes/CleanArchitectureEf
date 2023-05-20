using Example.Ecommerce.Domain.Entities.Common;

namespace Example.Ecommerce.Domain.Entities.Ecommerce;

public class ShoppingCartItemEntity : BaseDomainEntity
{
    #region Fields Prop

    public string? Product { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
    public string? Image { get; set; }
    public string? Category { get; set; }
    public int Stock { get; set; }
    public Guid? ShoppingCartMasterId { get; set; }

    #endregion Fields Prop

    #region Relations

    public int ProductId { get; set; }
    public int ShoppingCartId { get; set; }


    #endregion Relations


    #region Navigation props

    public virtual ShoppingCartEntity? ShoppingCart { get; set; }

    #endregion Navigation props
}