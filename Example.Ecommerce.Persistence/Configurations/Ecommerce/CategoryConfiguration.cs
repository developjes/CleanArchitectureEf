using Example.Ecommerce.Domain.Entities.Ecommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Persistence.Configurations.Ecommerce;

public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> categoryBuilder)
    {
        #region Rule properties

        #region General config

        categoryBuilder.ToTable(name: "Category", schema: "Ecommerce");

        #endregion General config

        #region Fields

        categoryBuilder.Property(product => product.Name)
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

        #endregion Seeder

        #endregion Rule properties
    }
}