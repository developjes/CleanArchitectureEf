using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Delete;
using Example.Ecommerce.Application.Interface.Persistence.Connector.Ef;
using Example.Ecommerce.Application.Validator.BusinessValidations.Feature.Ecommerce.Products.Delete;
using Example.Ecommerce.Domain.Entities.Ecommerce;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Example.Ecommerce.Application.UseCases.Features.Ecommerce.Products.Commands.Delete;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandDto, Unit>
{
    private readonly IEfUnitOfWork _efUnitOfWork;
    private readonly BusinessValidationDeleteProduct _businessValidationDeleteProduct;

    public DeleteProductCommandHandler(IEfUnitOfWork efUnitOfWork, BusinessValidationDeleteProduct businessValidationDeleteProduct)
    {
        _efUnitOfWork = efUnitOfWork;
        _businessValidationDeleteProduct = businessValidationDeleteProduct;
    }

    public async Task<Unit> Handle(DeleteProductCommandDto request, CancellationToken cancellationToken)
    {
        // Business validations
        await _businessValidationDeleteProduct.DeleteValidate(request);

        // Get current entity values
        ProductEntity? productToDelete = await _efUnitOfWork.EfRepository<ProductEntity>()
            .GetFirst(true, filter: x => x.Id.Equals(request.Id), cancellationToken: cancellationToken);

        // Delete Product
        _efUnitOfWork.EfRepository<ProductEntity>().Delete(productToDelete!);

        // Validation for save changes
        if (await _efUnitOfWork.EfCommit(cancellationToken: cancellationToken) <= sbyte.MinValue) // Commit changes
            throw new DbUpdateException($"Can't be delete sucessfull. Afected rows {sbyte.MinValue}"); // Exception validation

        return Unit.Value;
    }
}