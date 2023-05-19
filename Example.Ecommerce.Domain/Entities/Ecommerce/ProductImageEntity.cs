using Example.Ecommerce.Domain.Entities.Common;

namespace Example.Ecommerce.Domain.Entities.Ecommerce;

public class ProductImageEntity : BaseDomainEntity
{
    #region Fields Prop

    public string? Url { get; set; }
    public string? PublicCode { get; set; }

    #endregion Fields Prop

    #region Relations

    public int ProductId { get; set; }

    #endregion Relations

    #region Navigation props

    public virtual ProductEntity? Product { get; set; }

    #endregion Navigation props
}