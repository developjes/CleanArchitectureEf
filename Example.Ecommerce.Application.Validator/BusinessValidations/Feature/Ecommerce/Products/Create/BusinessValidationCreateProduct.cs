using Example.Ecommerce.Application.DTO.Features.Ecommerce.Products.Request.Create;
using Example.Ecommerce.Application.Interface.Persistence.Connector.Ef;
using Example.Ecommerce.Application.Validator.Exceptions;
using Example.Ecommerce.Domain.Entities.Ecommerce;

namespace Example.Ecommerce.Application.Validator.BusinessValidations.Feature.Ecommerce.Products.Create;

public class BusinessValidationCreateProduct
{
    private readonly IEfUnitOfWork _efUnitOfWork;

    public BusinessValidationCreateProduct(IEfUnitOfWork efUnitOfWork) =>
        _efUnitOfWork = efUnitOfWork;

    public async Task CreateValidate(CreateProductCommandDto request)
    {
        int countProduct = await _efUnitOfWork.EfRepository<ProductEntity>()
            .Count(false, filter: x => x.Name!.Equals(request.Name) && x.CategoryId.Equals(request.CategoryId));

        if (countProduct > ushort.MinValue)
        {
            throw new MessageValidationException(
                "CantExistProduct", $"Ya existe un producto con el nombre '{request.Name}' en la categoria #'{request.CategoryId}'");
        }
    }
}