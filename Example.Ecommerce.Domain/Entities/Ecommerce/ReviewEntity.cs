using Example.Ecommerce.Domain.Entities.Common;

namespace Example.Ecommerce.Domain.Entities.Ecommerce;

public sealed class ReviewEntity : BaseDomainEntity
{
    #region Fields Prop

    public string? Name { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }

    #endregion Fields Prop

    #region Relations

    public int ProductId { get; set; }

    #endregion Relations

    #region Navigation props

    #endregion Navigation props
}