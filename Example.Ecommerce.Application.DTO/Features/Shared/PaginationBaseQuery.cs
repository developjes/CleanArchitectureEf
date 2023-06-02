﻿using Swashbuckle.AspNetCore.Annotations;

namespace Example.Ecommerce.Application.DTO.Features.Shared;

public class PaginationBaseQuery
{
    private int _pageSize = 3;
    private const int MaxPageSize = 50;

    public string? Search { get; set; }
    public string? Sort { get; set; }
    public int PageIndex { get; set; } = 1;
    public int PageSize { get => _pageSize; set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
}