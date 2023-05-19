using AutoMapper;
using Example.Ecommerce.Application.DTO.ExternalServices;
using Example.Ecommerce.Application.DTO.Parametrization.Response;
using Example.Ecommerce.Application.DTO.Petition.Response;
using Example.Ecommerce.Domain.Entities.ExternalServices;
using Example.Ecommerce.Domain.Entities.Parametrization;
using Example.Ecommerce.Domain.Entities.Petition;

namespace Pacagroup.Ecommerce.Application.UseCases.Common.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<StateEntity, StateWithPetitionsDto>().ReverseMap();

            CreateMap<StateEntity, StateDto>().ReverseMap();
            CreateMap<IdentificationTypeEntity, IdentificationTypeDto>().ReverseMap();

            CreateMap<PetitionEntity, PetitionDto>().ReverseMap();
            CreateMap<HeadLineEntity, HeadLineDto>().ReverseMap();
            CreateMap<BeneficiaryEntity, BeneficiaryDto>().ReverseMap();

            // external pokemon api
            CreateMap<PokemonDetailDto, PokemonDetailData>().ReverseMap();
            CreateMap<SpriteDto, SpriteData>().ReverseMap();
            CreateMap<OtherDto, OtherData>().ReverseMap();
            CreateMap<OfficialArtWorkDto, OfficialArtWorkData>().ReverseMap();

            // GoRest
            CreateMap<GoRestGetPostDto, GoRestGetPostData>().ReverseMap();
            CreateMap<GoRestPostPostData, GoRestCreatePostDto
>().ReverseMap();
        }
    }
}