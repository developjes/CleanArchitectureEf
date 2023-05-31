using AutoMapper;
using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Read;
using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Response;
using Example.Ecommerce.Application.UseCases.Specifications.Product;
using Example.Ecommerce.Domain.Entities.Ecommerce;
using Example.Ecommerce.Domain.Enums.Parametrization;

namespace Example.Ecommerce.Application.UseCases.Mappings;

public class MappingsProfile : Profile
{
    public MappingsProfile() => CreateMapping();

    private void CreateMapping()
    {
        CreateMap<ProductEntity, ProductResponseDto>()
            .ForMember(e => e.StateId, e => e.MapFrom(s => (EProductState)s.StateId));

        CreateMap<PaginationProductListQueryDto, ProductSpecificationParams>().ReverseMap();
    }
}