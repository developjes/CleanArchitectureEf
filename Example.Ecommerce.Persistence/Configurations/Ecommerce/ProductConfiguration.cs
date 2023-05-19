using Example.Ecommerce.Domain.Entities.Ecommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Persistence.Configurations.Ecommerce;

public sealed class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> productBuilder)
    {
        #region Rule properties

        #region General config

        productBuilder.ToTable(name: "Product", schema: "Ecommerce");

        #endregion General config

        #region Fields

        productBuilder.Property(product => product.Name)
            .HasColumnName("Name")
            .HasComment("Product Name")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .HasColumnOrder(2)
            .IsRequired(required: true);

        productBuilder.Property(product => product.Price)
            .HasColumnName("Price")
            .HasComment("Product price")
            .HasColumnType("decimal")
            .HasPrecision(10, 2)
            .HasMaxLength(100)
            .HasColumnOrder(3)
            .IsRequired(required: true);

        productBuilder.Property(product => product.Description)
            .HasColumnName("Description")
            .HasComment("Product description")
            .HasColumnType("nvarchar")
            .HasMaxLength(4000)
            .HasColumnOrder(4)
            .IsRequired(required: false);

        productBuilder.Property(product => product.Rating)
            .HasColumnName("Rating")
            .HasComment("Product rating")
            .HasColumnType("int")
            .HasColumnOrder(5)
            .IsRequired(required: true);

        productBuilder.Property(product => product.Stock)
            .HasColumnName("Stock")
            .HasComment("Product stock")
            .HasColumnType("int")
            .HasColumnOrder(6)
            .IsRequired(required: true);

        productBuilder.Property(product => product.Seller)
            .HasColumnName("Seller")
            .HasComment("Product seller")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .HasColumnOrder(7)
            .IsRequired(required: true);

        productBuilder.Ignore(product => product.StateId);
        productBuilder.Property<int>("_stateId")
            .HasColumnName("StateId")
            .HasComment("Product ForeignKey State Table")
            .HasColumnType("int")
            .HasColumnOrder(8)
            .IsRequired(required: true);

        #endregion Fields

        #region Relationships

        productBuilder.HasOne(product => product.State)
            .WithMany(state => state.Products)
            .HasForeignKey("_stateId")
            .HasConstraintName("FK_Product_State_StateId")
            .OnDelete(DeleteBehavior.Restrict);

        #endregion Relationships

        #region Seeder

        #endregion Seeder

        #endregion Rule properties
    }
}