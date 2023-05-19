using Example.Ecommerce.Domain.Entities.Ecommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Persistence.Configurations.Ecommerce;

public sealed class ProductImageConfiguration : IEntityTypeConfiguration<ProductImageEntity>
{
    public void Configure(EntityTypeBuilder<ProductImageEntity> productImageBuilder)
    {
        #region Rule properties

        #region General config

        productImageBuilder.ToTable(name: "ProductImage", schema: "Ecommerce");

        #endregion General config

        #region Fields

        productImageBuilder.Property(productImage => productImage.Url)
            .HasColumnName("Url")
            .HasComment("ProductImage url")
            .HasColumnType("varchar")
            .HasMaxLength(4000)
            .HasColumnOrder(2)
            .IsUnicode(false)
            .IsRequired(required: true);

        productImageBuilder.Property(productImage => productImage.PublicCode)
            .HasColumnName("PublicCode")
            .HasComment("ProductImage PublicCode")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .HasColumnOrder(3)
            .IsUnicode(false)
            .IsRequired(required: true);

        productImageBuilder.Property(productImage => productImage.ProductId)
            .HasColumnName("ProductId")
            .HasComment("ProductImage ForeignKey Product Table")
            .HasColumnType("int")
            .HasColumnOrder(4)
            .IsRequired(required: true);

        #endregion Fields

        #region Relationships

        productImageBuilder.HasOne(productImage => productImage.Product)
            .WithMany(product => product.ProductImages)
            .HasForeignKey(productImage => productImage.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion Relationships

        #region Seeder

        #endregion Seeder

        #endregion Rule properties
    }
}