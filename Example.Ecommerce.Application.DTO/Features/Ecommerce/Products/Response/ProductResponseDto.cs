using Example.Ecommerce.Domain.Enums.Parametrization;

namespace Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Response;

public class ProductResponseDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int Rating { get; set; }
    public string? Seller { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public EProductState StateId { get; set; }
}