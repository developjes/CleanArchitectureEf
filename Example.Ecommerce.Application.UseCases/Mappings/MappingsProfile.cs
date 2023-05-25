using AutoMapper;
using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Response;
using Example.Ecommerce.Domain.Entities.Ecommerce;

namespace Example.Ecommerce.Application.UseCases.Mappings;

public class MappingsProfile : Profile
{
    public MappingsProfile() => CreateMapping();

    private void CreateMapping()
    {
        CreateMap<ProductEntity, ProductResponseDto>().ReverseMap();
    }
}