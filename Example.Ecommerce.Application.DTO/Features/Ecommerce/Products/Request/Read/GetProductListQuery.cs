using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Response;
using MediatR;

namespace Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Read;

public class GetProductListQuery : IRequest<IReadOnlyList<ProductResponseDto>> { }