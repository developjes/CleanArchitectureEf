using Microsoft.AspNetCore.Http;

namespace Example.Ecommerce.Application.DTO.Features.Shared.Create;

public class CreateResponseDto<T> where T : class
{
    public string? Type { get; set; } = "https://tools.ietf.org/html/rfc7231#section-6.3.2";
    public int Status { get; set; } = StatusCodes.Status201Created;
    public string? Title { get; set; } = "Creacion exitosa";
    public string? Detail { get; set; } = "Elemento insertado correctamente";
    public T? Content { get; set; }
}