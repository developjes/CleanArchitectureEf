using Example.Ecommerce.Application.DTO.ExternalServices;
using Example.Ecommerce.Application.DTO.Parametrization.Response;
using Example.Ecommerce.Application.DTO.Petition.Response;
using Example.Ecommerce.Application.Interface.UseCases.Parametrization;
using Example.Ecommerce.Application.Interface.UseCases.Petition;
using Example.Ecommerce.Application.UseCases.Parametrization;
using Example.Ecommerce.Application.UseCases.Petition;
using Example.Ecommerce.Transversal.Common.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Example.Ecommerce.Service.WebApi.Controllers.v1
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0", Deprecated = false)]
    [ApiExplorerSettings(IgnoreApi = false)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class HeadLineController: ControllerBase
    {
        private readonly IHeadLinesApplication _headLinesApplication;

        public HeadLineController(IHeadLinesApplication headLinesApplication)
        {
            _headLinesApplication = headLinesApplication;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            Response<IEnumerable<HeadLineDto>> response = await _headLinesApplication.GetAll();

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetAllPokemon")]
        public async Task<IActionResult> GetAllPokemon()
        {
            Response<PokemonServiceDto> response = await _headLinesApplication.GetAllPokemon();

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetDetailPokemon")]
        public async Task<IActionResult> GetDetailPokemon()
        {
            Response<PokemonDetailDto> response = await _headLinesApplication.GetDetailPokemon();

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
    }
}
