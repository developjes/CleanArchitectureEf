using Example.Ecommerce.Domain.Entities.Ecommerce;

namespace Example.Ecommerce.Application.UseCases.Specifications.Product;

public class ProductForCountingSpecification : SpecificationBase<ProductEntity>
{
    public ProductForCountingSpecification(ProductSpecificationParams productParams) : base(
        productEntity => (
            string.IsNullOrWhiteSpace(productParams.Search)
            || productEntity.Name!.Contains(productParams.Search)
            || productEntity.Description!.Contains(productParams.Search)
        )
        && (!productParams.MinPrice.HasValue || productEntity.Price >= productParams.MinPrice)
        && (!productParams.MaxPrice.HasValue || productEntity.Price <= productParams.MaxPrice)
        && (!productParams.StateId.HasValue || productEntity.StateId.Equals(productParams.StateId))
    )
    { }
}