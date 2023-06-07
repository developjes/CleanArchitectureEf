using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Delete;
using Example.Ecommerce.Application.Interface.Persistence.Connector.Ef;
using Example.Ecommerce.Application.Validator.BusinessValidations.Shared;

namespace Example.Ecommerce.Application.Validator.BusinessValidations.Feature.Ecommerce.Products.Delete;

public class BusinessValidationDeleteProduct
{
    private readonly IEfUnitOfWork _efUnitOfWork;

    public BusinessValidationDeleteProduct(IEfUnitOfWork efUnitOfWork) =>
        _efUnitOfWork = efUnitOfWork;

    public async Task DeleteValidate(DeleteProductCommandDto request)
    {
        // validate if exist Product by Id
        await GenericsValidation.MustExistProductById(request.Id, _efUnitOfWork);
    }
}