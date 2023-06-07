using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Create;
using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Delete;
using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Read;
using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Update;
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
/// Endpoints for Product
/// </summary>
[ApiController]
[SwaggerTag(description: "Endpoints CRUD for Product")]
[ApiExplorerSettings(IgnoreApi = false, GroupName = "Product")]
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
    [AllowAnonymous]
    [HttpGet]
    [Route("list", Name = "GetProductList")]
    [SwaggerOperation(OperationId = "ProductList", Tags = new[] { "Product" }
    )]
    [ProducesResponseType(typeof(IReadOnlyList<ProductResponseDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<ProductResponseDto>>> GetAll() =>
        Ok(await _mediator.Send(new GetProductListQueryDto()));

    /// <summary>
    /// Return Paginated product list
    /// </summary>
    [AllowAnonymous]
    [HttpGet("paginationList", Name = "PaginationProductList")]
    [SwaggerOperation(OperationId = "PaginationProductList", Tags = new[] { "Product" })]
    [ProducesResponseType(typeof(PaginationResponseDto<ProductResponseDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<PaginationResponseDto<ProductResponseDto>>> PaginationProduct(
        [FromQuery] PaginationProductListQueryDto paginationProductsQuery)
    {
        paginationProductsQuery.State = EProductState.Active;
        PaginationResponseDto<ProductResponseDto> paginationProduct = await _mediator.Send(paginationProductsQuery);

        return Ok(paginationProduct);
    }

    /// <summary>Create a new peoduct</summary>
    /// <remarks>
    /// <para>Sample request:
    ///
    /// POST api/Product/Store
    /// {
    ///     "name": "TV", *
    ///     "price": 400000, *
    ///     "description": "Televisor 24 pulgadas", *
    ///     "seller": "Junior Casas", *
    ///     "stock": 20, *
    ///     "categoryId": 1 *
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

    /// <summary>Update a product</summary>
    /// <remarks>
    /// <para>Sample request:
    ///
    /// -H 'accept: */*'
    /// -H 'Content-Type: application/json'
    ///
    /// PUT api/Product/1/Update/
    /// {
    ///     "Id": 1,
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
    [HttpPut("Update", Name = "UpdateProduct")]
    [HttpPatch("Patch", Name = "PatchUpdateProduct")]
    [SwaggerOperation(OperationId = "UpdateProduct", Tags = new[] { "Product" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ValidationMessageDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Unit>> Update([FromBody] UpdateProductCommandDto request)
    {
        await _mediator.Send(request);
        return StatusCode(StatusCodes.Status204NoContent);
    }

    /// <summary>Delete a product</summary>
    /// <remarks>
    /// <para>Sample request:
    ///
    /// -H 'accept: */*'
    /// -H 'Content-Type: application/json'
    ///
    /// DELETE api/Product/1/Update/
    /// </para>
    /// </remarks>
    [AllowAnonymous]
    [HttpDelete("{id:int:min(1)}/Delete", Name = "DeleteProduct")]
    [SwaggerOperation(OperationId = "DeleteProduct", Tags = new[] { "Product" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ValidationMessageDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Unit>> Delete(int id)
    {
        DeleteProductCommandDto request = new(id);

        await _mediator.Send(request);
        return StatusCode(StatusCodes.Status204NoContent);
    }

    #endregion Methods
}