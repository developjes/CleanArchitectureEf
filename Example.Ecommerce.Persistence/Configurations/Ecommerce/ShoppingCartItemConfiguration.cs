using Example.Ecommerce.Domain.Entities.Ecommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Persistence.Configurations.Ecommerce;

public sealed class ShoppingCartItemConfiguration : IEntityTypeConfiguration<ShoppingCartItemEntity>
{
    public void Configure(EntityTypeBuilder<ShoppingCartItemEntity> shoppingCartItemBuilder)
    {
        #region Rule properties

        #region General config

        shoppingCartItemBuilder.ToTable(name: "ShoppingCartItem", schema: "Ecommerce");

        #endregion General config

        #region Fields

        shoppingCartItemBuilder.Property(shoppingCartItem => shoppingCartItem.Product)
            .HasColumnName("Product")
            .HasComment("ShoppingCartItem Product")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .HasColumnOrder(2)
            .IsUnicode(false)
            .IsRequired(required: true);

        shoppingCartItemBuilder.Property(shoppingCartItem => shoppingCartItem.Price)
            .HasColumnName("Price")
            .HasComment("ShoppingCartItem price")
            .HasColumnType("decimal")
            .HasPrecision(10, 2)
            .HasColumnOrder(3)
            .IsRequired(required: true);

        shoppingCartItemBuilder.Property(shoppingCartItem => shoppingCartItem.Amount)
            .HasColumnName("Amount")
            .HasComment("ShoppingCartItem amount")
            .HasColumnType("int")
            .HasColumnOrder(4)
            .IsRequired(required: true);

        shoppingCartItemBuilder.Property(shoppingCartItem => shoppingCartItem.Image)
            .HasColumnName("Image")
            .HasComment("ShoppingCartItem Image")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .HasColumnOrder(5)
            .IsUnicode(false)
            .IsRequired(required: true);

        shoppingCartItemBuilder.Property(shoppingCartItem => shoppingCartItem.Category)
            .HasColumnName("Category")
            .HasComment("ShoppingCartItem Category")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .HasColumnOrder(6)
            .IsUnicode(false)
            .IsRequired(required: true);

        shoppingCartItemBuilder.Property(shoppingCartItem => shoppingCartItem.Stock)
            .HasColumnName("Stock")
            .HasComment("ShoppingCartItem stock")
            .HasColumnType("int")
            .HasColumnOrder(7)
            .IsRequired(required: true);

        shoppingCartItemBuilder.Property(shoppingCartItem => shoppingCartItem.ShoppingCartMasterId)
            .HasColumnName("ShoppingCartMasterId")
            //.ValueGeneratedOnAdd()
            .HasComment("ShoppingCartItem ShoppingCartMasterId")
            .HasColumnOrder(8)
            .IsRequired(required: true);

        shoppingCartItemBuilder.Property(productImage => productImage.ProductId)
            .HasColumnName("ProductId")
            .HasComment("shoppingCartItem ProductId")
            .HasColumnType("int")
            .HasColumnOrder(9)
            .IsRequired(required: true);

        shoppingCartItemBuilder.Property(shoppingCartItem => shoppingCartItem.ShoppingCartId)
            .HasColumnName("ShoppingCartId")
            .HasComment("shoppingCartItem ForeignKey ShoppingCart Table")
            .HasColumnType("int")
            .HasColumnOrder(10)
            .IsRequired(required: true);

        #endregion Fields

        #region Relationships

        shoppingCartItemBuilder.HasOne(shoppingCartItem => shoppingCartItem.ShoppingCart)
            .WithMany(shoppingCart => shoppingCart.ShoppingCartItems)
            .HasForeignKey(shoppingCartItem => shoppingCartItem.ShoppingCartId)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion Relationships

        #region Seeder

        #endregion Seeder

        #endregion Rule properties
    }
}