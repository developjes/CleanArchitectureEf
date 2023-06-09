﻿namespace Example.Ecommerce.Application.UseCases.Specifications;

public abstract class SpecificationParams
{
    private const int MaxPageSize = 50;
    public int PageIndex { get; set; } = 1;
    public string? Sort { get; set; }
    public int PageSize { get => _pageSize; set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
    private int _pageSize = 3;
    public string? Search { get; set; }
}