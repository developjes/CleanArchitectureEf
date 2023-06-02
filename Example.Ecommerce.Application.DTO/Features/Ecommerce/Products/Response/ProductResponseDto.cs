using Example.Ecommerce.Domain.Enums.Parametrization;
using Swashbuckle.AspNetCore.Annotations;

namespace Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Response;

[SwaggerSchema(Description = "Representa un producto")]
public class ProductResponseDto
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
    [SwaggerSchema(Description = "Relacion categoria", Nullable = false, Format = "int32 : 1", ReadOnly = true)]
    public int CategoryId { get; set; }
    [SwaggerSchema(Description = "Estado", Nullable = false, Format = "int32 : 1 or $string: \"Inactive\"", ReadOnly = true)]
    public EProductState StateId { get; set; }
}