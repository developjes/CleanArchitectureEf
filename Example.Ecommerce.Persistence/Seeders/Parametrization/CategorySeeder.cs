using Example.Ecommerce.Domain.Entities.Parametrization;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Persistence.Seeders.Parametrization;

public static class CategorySeeder
{
    public static EntityTypeBuilder<CategoryEntity> AddSeeder(this EntityTypeBuilder<CategoryEntity> categoryEntity)
    {
        categoryEntity.HasData(new HashSet<CategoryEntity>()
        {
            new() { Id = 1, Name = "Tecnologia", CreateAt = new DateTime(2023, 05, 19), CreatedBy = "System" },
            new() { Id = 2, Name = "Electrodomesticos", CreateAt = new DateTime(2023, 05, 19), CreatedBy = "System" },
            new() { Id = 3, Name = "Alimentos", CreateAt = new DateTime(2023, 05, 19), CreatedBy = "System" }
        });

        return categoryEntity;
    }
}