using Example.Ecommerce.Domain.Entities.Common;
using Example.Ecommerce.Domain.Enums.Parametrization;

namespace Example.Ecommerce.Domain.Entities.Ecommerce;

public sealed class ProductEntity : BaseDomainEntity
{
    #region Fields Prop

    public string? Nombre { get; set; }
    public decimal Precio { get; set; }
    public string? Descripcion { get; set; }
    public int Rating { get; set; }
    public int Stock { get; set; }
    public EProduct State { get; set; }

    #endregion Fields Prop

    #region Relations

    public int CategoryId { get; set; }

    #endregion Relations

    #region Navigation props

    #endregion Navigation props
}