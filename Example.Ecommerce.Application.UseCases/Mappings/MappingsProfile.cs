using AutoMapper;
using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Response;
using Example.Ecommerce.Application.UseCases.Features.Ecommerce.Products.Queries.PaginationProductList;
using Example.Ecommerce.Application.UseCases.Specifications.Product;
using Example.Ecommerce.Domain.Entities.Ecommerce;

namespace Example.Ecommerce.Application.UseCases.Mappings;

public class MappingsProfile : Profile
{
    public MappingsProfile() => CreateMapping();

    private void CreateMapping()
    {
        CreateMap<ProductEntity, ProductResponseDto>()
            .ForMember(e => (int)e.StateId, e => e.MapFrom(s => s.StateId));

        CreateMap<PaginationProductListQuery, ProductSpecificationParams>().ReverseMap();
    }
}