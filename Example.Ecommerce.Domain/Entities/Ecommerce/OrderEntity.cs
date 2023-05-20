using Example.Ecommerce.Domain.Entities.Common;
using Example.Ecommerce.Domain.Entities.Parametrization;
using Example.Ecommerce.Domain.Enums.Parametrization;

namespace Example.Ecommerce.Domain.Entities.Ecommerce;

public class OrderEntity : BaseDomainEntity
{
    public OrderEntity() { }

    public OrderEntity(
        string buyerName,
        string emailBuyer,
        OrderAddressEntity orderAddress,
        decimal subTotal,
        decimal total,
        decimal tax,
        decimal shippingPrice
    )
    {
        BuyerName = buyerName;
        BuyerUsername = emailBuyer;
        OrderAddress = orderAddress;
        SubTotal = subTotal;
        Total = total;
        Tax = tax;
        ShippingPrice = shippingPrice;
    }

    #region Fields Prop

    public string? BuyerName { get; set; }
    public string? BuyerUsername { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Total { get; set; }
    public decimal Tax { get; set; }
    public decimal ShippingPrice { get; set; }
    public string? ClientSecret { get; set; }
    public string? StripeApiKey { get; set; }
    public string? PaymentIntentId { get; set; }

    #endregion Fields Prop

    #region Relations

    public EOrderState StateId { get => (EOrderState)_stateId; set => _stateId = (int)value; }
    private int _stateId;

    #endregion Relations

    #region Navigation props

    public OrderAddressEntity? OrderAddress { get; set; }
    public StateEntity? State { get; set; }
    public ICollection<OrderItemEntity>? OrderItems { get; set; }

    #endregion Navigation props
}