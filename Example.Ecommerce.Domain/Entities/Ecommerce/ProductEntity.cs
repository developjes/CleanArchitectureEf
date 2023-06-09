﻿using Example.Ecommerce.Domain.Entities.Common;
using Example.Ecommerce.Domain.Entities.Parametrization;

namespace Example.Ecommerce.Domain.Entities.Ecommerce;

public class ProductEntity : BaseDomainEntity
{
    #region Fields Prop

    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public int Rating { get; set; }
    public int Stock { get; set; }
    public string? Seller { get; set; }

    #endregion Fields Prop

    #region Relations

    public int StateId { get; set; }
    public int CategoryId { get; set; }

    #endregion Relations

    #region Navigation props

    public StateEntity? State { get; set; }
    public virtual CategoryEntity? Category { get; set; }
    public virtual ICollection<ReviewEntity>? Reviews { get; set; }
    public virtual ICollection<ProductImageEntity>? ProductImages { get; set; }
    public virtual ICollection<OrderItemEntity>? OrderItems { get; set; }

    #endregion Navigation props
}