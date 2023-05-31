using Example.Ecommerce.Domain.Entities.Ecommerce;

namespace Example.Ecommerce.Application.UseCases.Specifications.Product;

public class ProductSpecification : SpecificationBase<ProductEntity>
{
    public ProductSpecification(ProductSpecificationParams productParams) : base(
        productEntity => (
            string.IsNullOrWhiteSpace(productParams.Search)
            || productEntity.Name!.Contains(productParams.Search)
            || productEntity.Description!.Contains(productParams.Search)
        )
        && (!productParams.MinPrice.HasValue || productEntity.Price >= productParams.MinPrice)
        && (!productParams.MaxPrice.HasValue || productEntity.Price <= productParams.MaxPrice)
        && (!productParams.StateId.HasValue || productEntity.StateId.Equals(productParams.StateId))
    )
    {
        AddInclude(productEntity => productEntity.Reviews!);
        AddInclude(productEntity => productEntity.ProductImages!);

        ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

        if (string.IsNullOrEmpty(productParams.Sort))
        {
            AddOrderByDescending(p => p.CreateAt!);
            return;
        }

        switch (productParams.Sort)
        {
            case "nameAsc": AddOrderBy(p => p.Name!);
                break;
            case "nameDesc": AddOrderByDescending(p => p.Name!);
                break;
            case "priceAsc": AddOrderBy(p => p.Price!);
                break;
            case "priceDesc": AddOrderByDescending(p => p.Price!);
                break;
            case "ratingAsc": AddOrderBy(p => p.Rating!);
                break;
            case "ratingDesc": AddOrderByDescending(p => p.Rating!);
                break;
            default: AddOrderBy(p => p.CreateAt!);
                break;
        }
    }
}