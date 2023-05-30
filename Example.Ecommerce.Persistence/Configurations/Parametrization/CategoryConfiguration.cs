using Example.Ecommerce.Domain.Entities.Parametrization;
using Example.Ecommerce.Persistence.Seeders.Parametrization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Persistence.Configurations.Parametrization;

public sealed class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> categoryBuilder)
    {
        #region Rule properties

        #region General config

        categoryBuilder.ToTable(name: "Category", schema: "Parametrization");

        #endregion General config

        #region Fields

        categoryBuilder.Property(category => category.Name)
            .HasColumnName("Name")
            .HasComment("Category Name")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .HasColumnOrder(2)
            .IsUnicode(false)
            .IsRequired(required: true);

        #endregion Fields

        #region Relationships

        categoryBuilder.HasMany(category => category.Products)
            .WithOne(product => product.Category)
            .HasForeignKey(category => category.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion Relationships

        #region Seeder

        categoryBuilder.AddSeeder();

        #endregion Seeder

        #endregion Rule properties
    }
}