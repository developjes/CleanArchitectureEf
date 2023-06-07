using MediatR;

namespace Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Delete;

public class DeleteProductCommandDto : IRequest<Unit>
{
    public int Id { get; set; }

    public DeleteProductCommandDto(int id) =>
        Id = id.Equals(ushort.MinValue) ? throw new ArgumentException(null, nameof(id)) : id;
}