using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Update;
using Example.Ecommerce.Application.Interface.Persistence.Connector.Ef;
using Example.Ecommerce.Application.Validator.BusinessValidations.Shared;

namespace Example.Ecommerce.Application.Validator.BusinessValidations.Feature.Ecommerce.Products.Update;

public class BusinessValidationUpdateProduct
{
    private readonly IEfUnitOfWork _efUnitOfWork;

    public BusinessValidationUpdateProduct(IEfUnitOfWork efUnitOfWork) =>
        _efUnitOfWork = efUnitOfWork;

    public async Task UpdateValidate(UpdateProductCommandDto request)
    {
        // validate if exist Product by Id
        await GenericsValidation.MustExistProductById(request.Id, _efUnitOfWork);
    }
}