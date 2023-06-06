using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Response.Read;
using Example.Ecommerce.Application.DTO.Features.Shared.Paginate;
using Example.Ecommerce.Domain.Enums.Parametrization;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Read;

public class PaginationProductListQueryDto : PaginationBaseQuery,
    IRequest<PaginationResponseDto<ProductResponseDto>>
{
    [SwaggerParameter(Description = "Precio max del producto")]
    public decimal? MaxPrice { get; set; }

    [SwaggerParameter(Description = "Precio min del producto")]
    public decimal? MinPrice { get; set; }

    [SwaggerParameter(Description = "Calificacion del producto")]
    public int? Rating { get; set; }

    [SwaggerParameter(Description = "Estado del producto")]
    public EProductState? State { get; set; }
}