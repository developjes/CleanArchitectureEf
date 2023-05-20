using Example.Ecommerce.Domain.Entities.Common;

namespace Example.Ecommerce.Domain.Entities.Ecommerce;

public class OrderItemEntity : BaseDomainEntity
{
    #region Fields Prop

    public decimal Price { get; set; }
    public int Amount { get; set; }
    public string? ProductName { get; set; }
    public string? ImageUrl { get; set; }
    public int ProductItemId { get; set; }

    #endregion Fields Prop

    #region Relations

    public int OrderId { get; set; }
    public int ProductId { get; set; }

    #endregion Relations

    #region Navigation Props

    public OrderEntity? Order { get; set; }
    public ProductEntity? Product { get; set; }

    #endregion Navigation Props
}