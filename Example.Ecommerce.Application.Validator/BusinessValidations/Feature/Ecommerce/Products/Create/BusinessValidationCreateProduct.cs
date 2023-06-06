using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Create;
using Example.Ecommerce.Application.Interface.Persistence.Connector.Ef;
using Example.Ecommerce.Application.Validator.Exceptions;
using Example.Ecommerce.Domain.Entities.Ecommerce;

namespace Example.Ecommerce.Application.Validator.BusinessValidations.Feature.Ecommerce.Products.Create;

public class BusinessValidationCreateProduct
{
    private IEfUnitOfWork EfUnitOfWork { get; set; }

    public BusinessValidationCreateProduct(IEfUnitOfWork efUnitOfWork) =>
        EfUnitOfWork = efUnitOfWork;

    public async Task CreateValidate(CreateProductCommandDto request)
    {
        int countProduct = await EfUnitOfWork.EfRepository<ProductEntity>()
            .Count(false, filter: x => x.Name!.Equals(request.Name) && x.CategoryId.Equals(request.CategoryId));

        if (countProduct >= 1)
            throw new MessageValidationException("CantExistProduct", "Ya existe un producto con el mismo nombre");
    }
}