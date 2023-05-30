using Example.Ecommerce.Domain.Entities.Ecommerce;
using Example.Ecommerce.Domain.Enums.Ecommerce;
using Example.Ecommerce.Domain.Enums.Parametrization;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Persistence.Seeders.Ecommerce;

public static class ProductSeeder
{
    public static EntityTypeBuilder<ProductEntity> AddSeeder(this EntityTypeBuilder<ProductEntity> productEntity)
    {
        productEntity.HasData(new HashSet<ProductEntity>()
        {
            new()
            {
                Id = 1,
                Name = "TV '20",
                Price = 2000000,
                Description = "Televisor 20 pulgadas",
                Rating = (int)EProductRating.Five,
                Stock = 200,
                Seller = "Camilo Obando",
                StateId = (int)EProductState.Active,
                CategoryId = 1,
                CreateAt = new DateTime(2023, 05, 19),
                CreatedBy = "System"
            },
            new()
            {
                Id = 2,
                Name = "Aspiradora",
                Price = 500000,
                Description = "Aspiradora plegable",
                Rating = (int)EProductRating.Three,
                Stock = 30,
                Seller = "Juan Salazar",
                StateId = (int)EProductState.Active,
                CategoryId = 2,
                CreateAt = new DateTime(2023, 05, 19),
                CreatedBy = "System"
            }
        });

        return productEntity;
    }
}