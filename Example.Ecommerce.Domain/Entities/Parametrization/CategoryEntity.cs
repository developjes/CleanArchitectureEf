using Example.Ecommerce.Domain.Entities.Common;
using Example.Ecommerce.Domain.Entities.Ecommerce;

namespace Example.Ecommerce.Domain.Entities.Parametrization;

public class CategoryEntity : BaseDomainEntity
{
    #region Fields Prop

    public string? Name { get; set; }

    #endregion Fields Prop

    #region Navigation Props

    public virtual ICollection<ProductEntity>? Products { get; set; }

    #endregion Navigation Props
}