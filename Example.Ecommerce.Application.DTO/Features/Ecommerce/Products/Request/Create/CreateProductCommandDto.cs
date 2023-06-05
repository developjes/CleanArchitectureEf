using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Response.Create;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Create;

public class CreateProductCommandDto : IRequest<CreateProductResponseDto>
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public string? Seller { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
}