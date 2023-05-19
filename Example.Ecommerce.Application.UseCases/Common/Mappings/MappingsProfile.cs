using AutoMapper;

namespace Pacagroup.Ecommerce.Application.UseCases.Common.Mappings;

public class MappingsProfile : Profile
{
    public MappingsProfile() => CreateMapping();

    private void CreateMapping()
    {
        //CreateMap<StateEntity, StateWithPetitionsDto>().ReverseMap()
    }
}