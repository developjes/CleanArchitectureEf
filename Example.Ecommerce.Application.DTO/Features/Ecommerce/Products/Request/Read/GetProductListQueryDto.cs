using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Response.Read;
using MediatR;

namespace Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Read;

public class GetProductListQueryDto : IRequest<IReadOnlyList<ProductResponseDto>> { }