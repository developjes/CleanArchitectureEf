using Example.Ecommerce.Domain.Entities.Common;

namespace Example.Ecommerce.Domain.Entities.Ecommerce;

public class OrderAddressEntity : BaseDomainEntity
{
    #region Fields Prop

    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Department { get; set; }
    public string? PostalCode { get; set; }
    public string? Username { get; set; }
    public string? Country { get; set; }

    #endregion Fields Prop

    #region Navigation props

    public OrderEntity? Order { get; set; }

    #endregion Navigation props
}