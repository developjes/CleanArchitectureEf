using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Response;
using Example.Ecommerce.Application.DTO.Features.Shared;
using Example.Ecommerce.Application.UseCases.Features.Shared.Queries;
using Example.Ecommerce.Domain.Enums.Parametrization;
using MediatR;

namespace Example.Ecommerce.Application.UseCases.Features.Ecommerce.Products.Queries.PaginationProductList;

public class PaginationProductListQuery : PaginationBaseQuery, IRequest<PaginationDto<ProductResponseDto>>
{
    public decimal? MaxPrice { get; set; }
    public decimal? MinPrice { get; set; }
    public int? Rating { get; set; }
    public EProductState? State { get; set; }
}