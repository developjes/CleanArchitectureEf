using Example.Ecommerce.Application.DTO.Parametrization.Response;
using Example.Ecommerce.Application.Interface.UseCases.Parametrization;
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
    public class StateController : ControllerBase
    {
        private readonly IStatesApplication _statesApplication;

        public StateController(IStatesApplication statesApplication)
        {
            _statesApplication = statesApplication;
        }

        /// <summary>
        /// Get all states
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            Response<IEnumerable<StateDto>> response = await _statesApplication.GetAll();

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        /// <summary>
        /// Get all states otra vez
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        [Route("GetById/{id:int:min(1)}")]
        public async Task<IActionResult> GetById(int id)
        {
            //CancellationTokenSource tokenSource = new()
            //CancellationToken cts = default

            Response<StateDto> response = await _statesApplication.GetById(id);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        /// <summary>
        /// Get all states otra vez
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        [Route("GetAllByIdSP/{id:int:min(1)}")]
        public async Task<IActionResult> GetAllByIdSP(int id)
        {
            //CancellationTokenSource tokenSource = new()
            //CancellationToken cts = default

            Response<IEnumerable<StateDto>> response = await _statesApplication.GetByIdSP(id);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
    }
}