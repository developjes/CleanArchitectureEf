using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Create;
using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Read;
using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Response;
using Example.Ecommerce.Application.DTO.Features.Shared;
using Example.Ecommerce.Domain.Enums.Parametrization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Example.Ecommerce.Service.WebApi.Controllers.v1;

/// <summary>
/// All methods for Product data
/// </summary>
[ApiController]
[SwaggerTag("Get Weather forecast and place orders. Very weird and unstructed API :)")]
[ApiExplorerSettings(IgnoreApi = false)]
[ApiVersion("1.0", Deprecated = false)]
[Route("api/v{version:apiVersion}/[controller]")]
public sealed class ProductController : ControllerBase
{
    #region Services

    private readonly IMediator _mediator;

    #endregion Services

    #region Constructor

    /// <summary>
    /// Constructor using dependency injection
    /// </summary>
    /// <param name="mediator">Allow comunication between layers</param>
    public ProductController(IMediator mediator) => _mediator = mediator;

    #endregion Constructor

    #region Methods

    /// <summary>
    /// Return all product list
    /// </summary>
    /// <returns>ProductResponseDto</returns>
    [AllowAnonymous]
    [HttpGet]
    [Route("list", Name = "GetProductList")]
    [ProducesResponseType(typeof(IReadOnlyList<ProductResponseDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<ProductResponseDto>>> GetAll() =>
        Ok(await _mediator.Send(new GetProductListQueryDto()));

    /// <summary>
    /// Return Paginated product list
    /// </summary>
    /// <param name="paginationProductsQuery"></param>
    /// <returns>ProductResponseDto</returns>
    [AllowAnonymous]
    [HttpGet("paginationList", Name = "PaginationProductList")]
    [SwaggerOperation(
        Description = "Retona resultados paginados", OperationId = "PaginationProductList", Tags = new[] { "Products" }
    )]
    [ProducesResponseType(typeof(PaginationResponseDto<ProductResponseDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PaginationResponseDto<ProductResponseDto>>> PaginationProduct(
        [FromQuery] PaginationProductListQueryDto paginationProductsQuery)
    {
        paginationProductsQuery.State = EProductState.Active;
        PaginationResponseDto<ProductResponseDto> paginationProduct = await _mediator.Send(paginationProductsQuery);

        return Ok(paginationProduct);
    }

    [AllowAnonymous]
    [HttpPost("Store", Name = "StoreProduct")]
    [SwaggerOperation(
        Description = "Inserta un producto", OperationId = "InsertProduct", Tags = new[] { "Products" }
    )]
    public async Task<ActionResult<int>> PostController([FromBody] CreateProductCommandDto request)
    {
        return await _mediator.Send(request);
    }

    [AllowAnonymous]
    [SwaggerOperation(Tags = new[] { "Products" })]
    [HttpPut("pruebaPut", Name = "PruebaPut")]
    public IActionResult PutController()
    {
        return Ok();
    }

    [AllowAnonymous]
    [SwaggerOperation(Tags = new[] { "Products" })]
    [HttpPatch("pruebaPatch", Name = "PruebaPatch")]
    public IActionResult PatchController()
    {
        return Ok();
    }

    [AllowAnonymous]
    [SwaggerOperation(Tags = new[] { "Products" })]
    [HttpDelete("pruebaDelete", Name = "PruebaDelete")]
    public IActionResult DeleteController()
    {
        return Ok();
    }

    #endregion Methods
}