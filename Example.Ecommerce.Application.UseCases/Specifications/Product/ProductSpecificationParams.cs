using Example.Ecommerce.Domain.Enums.Parametrization;

namespace Example.Ecommerce.Application.UseCases.Specifications.Product;

public class ProductSpecificationParams : SpecificationParams
{
    public decimal? MaxPrice { get; set; }
    public decimal? MinPrice { get; set; }
    public int? Rating { get; set; }
    public EProductState? StateId { get; set; }
}