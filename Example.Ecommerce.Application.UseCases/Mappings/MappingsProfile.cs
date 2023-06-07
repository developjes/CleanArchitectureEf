using AutoMapper;
using Example.Ecommerce.Application.DTO.Features.Ecommerce.Category.Response.Create;
using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Create;
using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Read;
using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Update;
using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Response.Create;
using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Response.Read;
using Example.Ecommerce.Application.DTO.Features.Parametrization.State.Response.Create;
using Example.Ecommerce.Application.UseCases.Specifications.Product;
using Example.Ecommerce.Domain.Entities.Ecommerce;
using Example.Ecommerce.Domain.Entities.Parametrization;
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

        // Create category
        CreateMap<CreateProductCommandDto, ProductEntity>();
        CreateMap<UpdateProductCommandDto, ProductEntity>();

        CreateMap<CategoryEntity, CreateCategoryResponseDto>();
        CreateMap<StateEntity, CreateStateResponseDto>();
        //.ForAllMembers(opt => opt.Condition((src, dest, sourceMember) => sourceMember is not null));
        //.ForMember(dest => dest.Code, opt => opt.Condition(source => source.Id == 0))

        CreateMap<ProductEntity, CreateProductResponseDto>();
    }
}