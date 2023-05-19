using Example.Ecommerce.Domain.Entities.Common;

namespace Example.Ecommerce.Domain.Entities.Ecommerce;

public class CategoryEntity : BaseDomainEntity
{
    #region Fields Prop

    public string? Name { get; set; }

    #endregion Fields Prop

    #region Relations

    public virtual ICollection<ProductEntity>? Products { get; set; }

    #endregion Relations
}