using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Response;
using Example.Ecommerce.Application.DTO.Features.Shared;
using Example.Ecommerce.Domain.Enums.Parametrization;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Read;

public class PaginationProductListQueryDto : PaginationBaseQuery,
    IRequest<PaginationResponseDto<ProductResponseDto>>
{
    [SwaggerSchema(Description = "Max jes price", Nullable = true, Format = "$doculeeee")]
    public decimal? MaxPrice { get; set; }
    public decimal? MinPrice { get; set; }
    public int? Rating { get; set; }
    public EProductState? State { get; set; }
}