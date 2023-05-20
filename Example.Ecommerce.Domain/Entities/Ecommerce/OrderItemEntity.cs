using Example.Ecommerce.Domain.Entities.Common;

namespace Example.Ecommerce.Domain.Entities.Ecommerce;

public class OrderItemEntity : BaseDomainEntity
{
    public decimal Price { get; set; }
    public int Amount { get; set; }
    public string? ProductName { get; set; }
    public string? ImageUrl { get; set; }


    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int ProductItemId { get; set; }

    public OrderEntity? Order { get; set; }
    public ProductEntity? Product { get; set; }
}