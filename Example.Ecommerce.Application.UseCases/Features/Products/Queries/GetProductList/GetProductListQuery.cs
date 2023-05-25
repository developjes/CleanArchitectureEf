using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Response;
using MediatR;

namespace Example.Ecommerce.Application.UseCases.Features.Products.Queries.GetProductList;

public class GetProductListQuery : IRequest<IReadOnlyList<ProductResponseDto>> { }