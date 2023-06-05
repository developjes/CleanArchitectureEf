namespace Example.Ecommerce.Application.DTO.Features.Ecommerce.ProductImage.Request.Create;

public class CreateProductImageResponseDto
{
    public string? Url { get; set; }
    public int ProductId { get; set; }
    public string? PublicCode { get; set; }
}