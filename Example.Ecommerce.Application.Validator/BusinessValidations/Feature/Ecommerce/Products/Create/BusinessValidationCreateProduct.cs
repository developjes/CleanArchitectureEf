using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Create;
using Example.Ecommerce.Application.Interface.Persistence.Connector.Ef;
using Example.Ecommerce.Application.Validator.BusinessValidations.Shared;

namespace Example.Ecommerce.Application.Validator.BusinessValidations.Feature.Ecommerce.Products.Create;

public sealed class BusinessValidationCreateProduct
{
    private readonly IEfUnitOfWork _efUnitOfWork;

    public BusinessValidationCreateProduct(IEfUnitOfWork efUnitOfWork) =>
        _efUnitOfWork = efUnitOfWork;

    public async Task CreateValidate(CreateProductCommandDto request)
    {
        // validate if exist Product with the same name and category
        await GenericsValidation.MustnExistProductByNameAndCategoryId(request.Name!, request.CategoryId, _efUnitOfWork);
    }
}