using Example.Ecommerce.Application.DTO.Features.Ecommerce.Category.Response.Create;
using Example.Ecommerce.Application.DTO.Features.Parametrization.State.Response.Create;
using Swashbuckle.AspNetCore.Annotations;

namespace Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Response.Create;

[SwaggerSchema(Description = "Representa un producto")]
public class CreateProductResponseDto
{
    [SwaggerSchema(Description = "Id unico", Nullable = false, Format = "int32 : 1", ReadOnly = true)]
    public int Id { get; set; }
    [SwaggerSchema(Description = "Nombre del producto", Nullable = false, Format = "string : \"TV\"", ReadOnly = true)]
    public string? Name { get; set; }
    [SwaggerSchema(Description = "Precio del producto", Nullable = false, Format = "decimal : 30.5", ReadOnly = true)]
    public decimal Price { get; set; }
    [SwaggerSchema(Description = "Calificacion del producto", Nullable = false, Format = "int32 : 5", ReadOnly = true)]
    public int Rating { get; set; }
    [SwaggerSchema(Description = "Vendedor", Nullable = false, Format = "string : \"Carlos Obando\"", ReadOnly = true)]
    public string? Seller { get; set; }
    [SwaggerSchema(Description = "Cantidad en stock", Nullable = false, Format = "int32 : 400", ReadOnly = true)]
    public int Stock { get; set; }
    public int ReviewsCount { get; set; }
    public CreateCategoryResponseDto? Category { get; set; }
    public CreateStateResponseDto? State { get; set; }
}