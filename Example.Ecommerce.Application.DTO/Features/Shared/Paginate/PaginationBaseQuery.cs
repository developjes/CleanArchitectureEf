using Swashbuckle.AspNetCore.Annotations;

namespace Example.Ecommerce.Application.DTO.Features.Shared.Paginate;

public class PaginationBaseQuery
{
    private int _pageSize = 3;
    private const int MaxPageSize = 50;

    [SwaggerParameter(Description = "Search")]
    public string? Search { get; set; }
    [SwaggerParameter(Description = "Sort")]
    public string? Sort { get; set; }
    [SwaggerParameter(Description = "PageIndex")]
    public int PageIndex { get; set; } = 1;
    [SwaggerParameter(Description = "PageSize")]
    public int PageSize { get => _pageSize; set => _pageSize = value > MaxPageSize ? MaxPageSize : value; }
}