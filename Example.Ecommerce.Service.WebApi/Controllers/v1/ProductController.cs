using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Response;
using Example.Ecommerce.Application.Interface.Persistence.ImageCloudinary;
using Example.Ecommerce.Application.UseCases.Features.Products.Queries.GetProductList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Example.Ecommerce.Service.WebApi.Controllers.v1;

[ApiController]
[ApiExplorerSettings(IgnoreApi = false)]
[ApiVersion("1.0", Deprecated = false)]
[Route("api/v{version:apiVersion}/[controller]")]
public sealed class ProductController : ControllerBase
{
    #region Services

    private readonly IMediator _mediator;
    private readonly IManageImageService _manageImageService;

    #endregion Services

    #region Constructor

    public ProductController(IMediator mediator, IManageImageService manageImageService) =>
        (_mediator, _manageImageService) = (mediator, manageImageService);

    #endregion Constructor

    #region Methods

    [AllowAnonymous]
    [HttpGet]
    [Route("list", Name = "GetProductList")]
    [ProducesResponseType(typeof(IReadOnlyList<ProductResponseDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetAll()
    {
        GetProductListQuery query = new();
        IReadOnlyList<ProductResponseDto> products = await _mediator.Send(query);

        return Ok(products);
    }

    #endregion Methods
}