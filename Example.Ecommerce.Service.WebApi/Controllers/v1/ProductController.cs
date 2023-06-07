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
[SwaggerTag(description: "Product Actions. Ecommerce API :D")]
[ApiExplorerSettings(IgnoreApi = false, GroupName = "Product Endpoints XD")]
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
    [SwaggerOperation(
        Description = "Retorna todos los resultados", OperationId = "ProductList", Tags = new[] { "Product Endpoints XD" }
    )]
    [ProducesResponseType(typeof(IReadOnlyList<ProductResponseDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<ProductResponseDto>>> GetAll() =>
        Ok(await _mediator.Send(new GetProductListQueryDto()));

    /// <summary>
    /// Return Paginated product list
    /// </summary>
    [AllowAnonymous]
    [HttpGet("paginationList", Name = "PaginationProductList")]
    [SwaggerOperation(
        Description = "Retorna resultados paginados", OperationId = "PaginationProductList", Tags = new[] { "Product Endpoints XD" }
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
    [SwaggerOperation(OperationId = "StoreProduct", Tags = new[] { "Product Endpoints XD" })]
    [ProducesResponseType(typeof(CreateIdResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ValidationMessageDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateIdResponseDto>> Store([FromBody] CreateProductCommandDto request)
    {
        CreateIdResponseDto response = await _mediator.Send(request);
        return StatusCode(response.Status, response);
    }

    /// <summary>Actualizar un producto</summary>
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
    [SwaggerOperation(OperationId = "UpdateProduct", Tags = new[] { "Product Endpoints XD" })]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ValidationMessageDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Unit>> Update([FromBody] UpdateProductCommandDto request)
    {
        await _mediator.Send(request);
        return StatusCode(StatusCodes.Status204NoContent);
    }

    /// <summary>Eliminar un producto</summary>
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
    [SwaggerOperation(OperationId = "DeleteProduct", Tags = new[] { "Product Endpoints XD" })]
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