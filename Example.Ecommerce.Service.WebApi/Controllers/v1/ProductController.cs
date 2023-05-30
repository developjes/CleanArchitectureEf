using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Read;
using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Response;
using Example.Ecommerce.Application.DTO.Features.Shared;
using Example.Ecommerce.Domain.Enums.Parametrization;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Example.Ecommerce.Service.WebApi.Controllers.v1;

/// <summary>
/// All methods for Product data
/// </summary>
[ApiController]
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
    [ProducesResponseType(typeof(IReadOnlyList<ProductResponseDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IReadOnlyList<ProductResponseDto>>> GetAll()
    {
        GetProductListQuery query = new();
        IReadOnlyList<ProductResponseDto> products = await _mediator.Send(query);

        return Ok(products);
    }

    /// <summary>
    /// Return Paginated product list
    /// </summary>
    /// <param name="paginationProductsQuery"></param>
    /// <returns>ProductResponseDto</returns>
    [AllowAnonymous]
    [HttpGet("paginationList", Name = "PaginationProductList")]
    [ProducesResponseType(typeof(PaginationResponseDto<ProductResponseDto>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<PaginationResponseDto<ProductResponseDto>>> PaginationProduct(
        [FromQuery] PaginationProductListQuery paginationProductsQuery)
    {
        paginationProductsQuery.State = EProductState.Active;
        PaginationResponseDto<ProductResponseDto> paginationProduct = await _mediator.Send(paginationProductsQuery);

        return Ok(paginationProduct);
    }

    #endregion Methods
}