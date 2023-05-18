using Example.Ecommerce.Application.DTO.ExternalServices;
using Example.Ecommerce.Application.DTO.Petition.Response;
using Example.Ecommerce.Transversal.Common.Generic;

namespace Example.Ecommerce.Application.Interface.UseCases.Petition
{
    public interface IHeadLinesApplication
    {
        Task<Response<IEnumerable<HeadLineDto>>> GetAll();
        Task<Response<PokemonServiceDto>> GetAllPokemon();

        Task<Response<PokemonDetailDto>> GetDetailPokemon();
    }
}
