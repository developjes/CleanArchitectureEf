using MediatR;

namespace Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Create;

public class CreateProductCommandDto : IRequest<int>
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public int Rating { get; set; }
    public int Stock { get; set; }
    public string? Seller { get; set; }

    public int StateId { get; set; }
    public int CategoryId { get; set; }
}