﻿using Example.Ecommerce.Domain.Entities.Common;
using Example.Ecommerce.Domain.Entities.Parametrization;
using Example.Ecommerce.Domain.Enums.Parametrization;

namespace Example.Ecommerce.Domain.Entities.Ecommerce;

public sealed class ProductEntity : BaseDomainEntity
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

    public EProductState StateId { get => (EProductState)_stateId; set => _stateId = (int)value; }
    private int _stateId;

    public int CategoryId { get; set; }

    #endregion Relations

    #region Navigation props

    public StateEntity? State { get; set; }

    #endregion Navigation props
}