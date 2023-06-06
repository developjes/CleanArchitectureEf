using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Create;
using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Read;
using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Response.Create;
using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Response.Read;
using Example.Ecommerce.Application.DTO.Features.Shared.Create;
using Example.Ecommerce.Application.DTO.Features.Shared.Paginate;
using Example.Ecommerce.Domain.Enums.Parametrization;
using Example.Ecommerce.Service.WebApi.Models.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Example.Ecommerce.Service.WebApi.Controllers.v1;

/// <summary>
/// All methods for Product data
/// </summary>
[ApiController]
[SwaggerTag("Product Actions. Ecommerce API :D")]
[ApiExplorerSettings(IgnoreApi = false)]
[ApiVersion("1.0", Deprecated = false)]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces("application/json")]
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
        Description = "Retona resultados paginados", OperationId = "PaginationProductList", Tags = new[] { "Product" }
    )]
    [ProducesResponseType(typeof(PaginationResponseDto<ProductResponseDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PaginationResponseDto<ProductResponseDto>>> PaginationProduct(
        [FromQuery] PaginationProductListQueryDto paginationProductsQuery)
    {
        paginationProductsQuery.State = EProductState.Active;
        PaginationResponseDto<ProductResponseDto> paginationProduct = await _mediator.Send(paginationProductsQuery);

        return Ok(paginationProduct);
    }

    /// <summary>Insertar un producto</summary>
    /// <remarks>
    /// <para>Sample request:
    ///
    /// POST api/Product/Store
    /// {
    ///     "name": "TV",
    ///     "price": 400000,
    ///     "description": "Televisor 24 pulgadas",
    ///     "seller": "Junior Casas",
    ///     "stock": 20,
    ///     "categoryId": 1
    /// }
    /// </para>
    /// </remarks>
    [AllowAnonymous]
    [HttpPost("Store", Name = "StoreProduct")]
    [SwaggerOperation(OperationId = "StoreProduct", Tags = new[] { "Product" })]
    [ProducesResponseType(typeof(CreateIdResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ValidationMessageDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateIdResponseDto>> Store([FromBody] CreateProductCommandDto request)
    {
        CreateIdResponseDto response = await _mediator.Send(request);
        return StatusCode(response.Status, response);
    }


    [AllowAnonymous]
    [SwaggerOperation(Tags = new[] { "Product" })]
    [HttpPut("pruebaPut", Name = "PruebaPut")]
    public IActionResult PutController()
    {
        return Ok();
    }

    [AllowAnonymous]
    [SwaggerOperation(Tags = new[] { "Product" })]
    [HttpPatch("pruebaPatch", Name = "PruebaPatch")]
    public IActionResult PatchController()
    {
        return Ok();
    }

    [AllowAnonymous]
    [SwaggerOperation(Tags = new[] { "Product" })]
    [HttpDelete("pruebaDelete", Name = "PruebaDelete")]
    public IActionResult DeleteController()
    {
        return Ok();
    }

    #endregion Methods
}