using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Update;
using Example.Ecommerce.Application.Interface.Persistence.Connector.Ef;
using Example.Ecommerce.Application.Validator.BusinessValidations.Feature.Ecommerce.Products.Update;
using Example.Ecommerce.Domain.Entities.Ecommerce;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Example.Ecommerce.Application.UseCases.Features.Ecommerce.Products.Commands.Update;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandDto, Unit>
{
    private readonly IEfUnitOfWork _efUnitOfWork;
    private readonly BusinessValidationUpdateProduct _businessValidationUpdateProduct;

    public UpdateProductCommandHandler(IEfUnitOfWork efUnitOfWork, BusinessValidationUpdateProduct businessValidationUpdateProduct)
    {
        _efUnitOfWork = efUnitOfWork;
        _businessValidationUpdateProduct = businessValidationUpdateProduct;
    }

    public async Task<Unit> Handle(UpdateProductCommandDto request, CancellationToken cancellationToken)
    {
        // Business validations
        await _businessValidationUpdateProduct.UpdateValidate(request);

        // Get current entity values
        ProductEntity? productToUpdate = await _efUnitOfWork.EfRepository<ProductEntity>()
            .GetFirst(true, filter: x => x.Id.Equals(request.Id), cancellationToken: cancellationToken);

        // Mapper entity
        _efUnitOfWork.EfRepository<ProductEntity>().Patch(productToUpdate, request);

        // Validation for save changes
        if (await _efUnitOfWork.EfCommit(cancellationToken: cancellationToken) <= sbyte.MinValue) // Commit changes
            throw new DbUpdateException($"Can't be updated sucessfull. Afected rows {sbyte.MinValue}"); // Exception validation

        return Unit.Value;
    }
}
