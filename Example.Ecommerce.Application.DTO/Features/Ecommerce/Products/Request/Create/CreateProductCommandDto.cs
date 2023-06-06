using Example.Ecommerce.Application.DTO.Features.Shared.Create;
using MediatR;

namespace Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Create;

public class CreateProductCommandDto : IRequest<CreateIdResponseDto>
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public string? Seller { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
}