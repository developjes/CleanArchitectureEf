using Example.Ecommerce.Domain.Entities.Common;
using Example.Ecommerce.Domain.Enums.Parametrization;

namespace Example.Ecommerce.Domain.Entities.Ecommerce;

public class OrderEntity : BaseDomainEntity
{
    public string? CompradorNombre { get; set; }
    public string? CompradorUsername { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Total { get; set; }
    public decimal Impuesto { get; set; }
    public decimal PrecioEnvio { get; set; }
    public string? ClientSecret { get; set; }
    public string? StripeApiKey { get; set; }
    public EOrderState State { get; set; }

    public string? PaymentIntentId { get; set; }

    public OrderAddressEntity? OrderAddress { get; set; }
    public ICollection<OrderItemEntity>? OrderItems { get; set; }
}