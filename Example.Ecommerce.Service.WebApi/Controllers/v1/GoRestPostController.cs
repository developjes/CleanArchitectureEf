using Example.Ecommerce.Application.DTO.ExternalServices;
using Example.Ecommerce.Application.DTO.Petition.Response;
using Example.Ecommerce.Application.Interface.UseCases.Petition;
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
    public class GoRestPostController : ControllerBase
    {
        private readonly IGoRestPostApplication _goRestPostApplication;

        public GoRestPostController(IGoRestPostApplication goRestPostApplication)
        {
            _goRestPostApplication = goRestPostApplication;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            Response<List<GoRestGetPostDto>> response = await _goRestPostApplication.GetPosts();

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] GoRestCreatePostDto post)
        {
            Response<GoRestCreatePostDto> response = await _goRestPostApplication.CreatePosts(post);

            if (response.IsSuccess) return Ok(response);

            return BadRequest(response.Message);
        }
    }
}
