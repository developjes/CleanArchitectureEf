using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Response;
using Example.Ecommerce.Application.DTO.Features.Shared;
using Example.Ecommerce.Domain.Enums.Parametrization;
using MediatR;

namespace Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Read;

public class PaginationProductListQueryDto : PaginationBaseQuery, IRequest<PaginationResponseDto<ProductResponseDto>>
{
    public decimal? MaxPrice { get; set; }
    public decimal? MinPrice { get; set; }
    public int? Rating { get; set; }
    public EProductState? State { get; set; }
}