using Example.Ecommerce.Application.Interface.Persistence.Connector.Ef;
using Example.Ecommerce.Application.Validator.Exceptions;
using Example.Ecommerce.Domain.Entities.Ecommerce;

namespace Example.Ecommerce.Application.Validator.BusinessValidations.Shared;

public static class GenericsValidation
{
    public async static Task MustnExistProductByNameAndCategoryId(string productName, int categoryId, IEfUnitOfWork efUnitOfWork)
    {
        ProductEntity? productEntity = await efUnitOfWork.EfRepository<ProductEntity>()
            .GetFirst(false, filter: x => x.Name!.Equals(productName) && x.CategoryId.Equals(categoryId));

        if (productEntity is not null)
        {
            throw new MessageValidationException(
                "MustnExistProduct", $"A product with the name '{productName}' already exists in category #'{categoryId}'");
        }
    }

    public async static Task MustExistProductById(int productId, IEfUnitOfWork efUnitOfWork)
    {
        _ = await efUnitOfWork.EfRepository<ProductEntity>()
            .GetFirst(false, filter: x => x.Id.Equals(productId)) ?? throw new NotFoundException($"Entity \"{nameof(ProductEntity)}\" was not found.");
    }
}