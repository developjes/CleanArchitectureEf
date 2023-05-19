using AutoMapper;
using Example.Ecommerce.Application.DTO.ExternalServices;
using Example.Ecommerce.Application.DTO.Petition.Response;
using Example.Ecommerce.Application.Interface.Persistence.Connector.Ef;
using Example.Ecommerce.Application.Interface.Persistence.ExternalServices;
using Example.Ecommerce.Application.Interface.UseCases.Petition;
using Example.Ecommerce.Domain.Entities.ExternalServices;
using Example.Ecommerce.Domain.Entities.Petition;
using Example.Ecommerce.Transversal.Common.Generic;
using System.Linq.Expressions;

namespace Example.Ecommerce.Application.UseCases.Petition
{
    public class HeadLinesApplication : IHeadLinesApplication
    {
        private readonly IEfUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRestService _restService;

        public HeadLinesApplication(IEfUnitOfWork unitOfWork, IMapper mapper, IRestService restService) =>
            (_unitOfWork, _mapper, _restService) = (unitOfWork, mapper, restService);

        public async Task<Response<IEnumerable<HeadLineDto>>> GetAll()
        {
            Response<IEnumerable<HeadLineDto>> response = new();

            try
            {
                IEnumerable<HeadLineEntity> d = await _unitOfWork.EfRepository<HeadLineEntity>().Get();

                response.Data = _mapper.Map<List<HeadLineDto>>(await _unitOfWork.EfRepository<HeadLineEntity>().Get(
                    asTracking: false,
                    includeProperties: new Expression<Func<HeadLineEntity, object>>[]
                    {
                        x => x.IdentificationType!,
                        x => x.Beneficiaries!,
                        x => x.Petitions!
                    }
                ));

                if (response.Data is not null)
                {
                    response.IsSuccess = true;
                    response.Message = new()
                    {
                        Key = "Success",
                        Description = "Consulta Exitosa!!!"
                    };
                }
            }
            catch (Exception e)
            {
                response.Message = new()
                {
                    Key = "Error",
                    Description = e.Message
                };
            }

            return response;
        }

        //Externos
        public async Task<Response<PokemonServiceDto>> GetAllPokemon()
        {
            Response<PokemonServiceDto> response = new();

            string url = "https://pokeapi.co/api/v2/pokemon";
            response.Data = await _restService.GetJson<PokemonServiceDto>(url);

            if (response.Data is not null)
            {
                response.IsSuccess = true;
                response.Message = new()
                {
                    Key = "Success",
                    Description = "Consulta Exitosa!!!"
                };
            }

            return response;
        }

        public async Task<Response<PokemonDetailDto>> GetDetailPokemon()
        {
            Response<PokemonDetailDto> response = new();

            string url = "https://pokeapi.co/api/v2/pokemon/pikachu";
            response.Data = _mapper.Map<PokemonDetailDto>(await _restService.GetJson<PokemonDetailData>(url));

            if (response.Data is not null)
            {
                response.IsSuccess = true;
                response.Message = new()
                {
                    Key = "Success",
                    Description = "Consulta Exitosa!!!"
                };
            }

            return response;
        }
    }
}