using Microsoft.AspNetCore.Http;

namespace Example.Ecommerce.Application.DTO.Features.Shared.Create;

public class CreateIdResponseDto
{
    public string? Type { get; set; } = "https://tools.ietf.org/html/rfc7231#section-6.3.2";
    public int Status { get; set; } = StatusCodes.Status201Created;
    public int Id { get; set; }
    public string? Title { get; set; } = "Creacion exitosa";
    public string? Detail { get; set; } = "Elemento insertado correctamente";
}