using Example.Ecommerce.Domain.Entities.Ecommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Persistence.Configurations.Ecommerce;

public sealed class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCartEntity>
{
    public void Configure(EntityTypeBuilder<ShoppingCartEntity> shoppingCartBuilder)
    {
        #region Rule properties

        #region General config

        shoppingCartBuilder.ToTable(name: "ShoppingCart", schema: "Ecommerce");

        #endregion General config

        #region Fields

        shoppingCartBuilder.Property(shoppingCartItem => shoppingCartItem.ShoppingCartMasterId)
            .HasColumnName("ShoppingCartMasterId")
            //.ValueGeneratedOnAdd()
            .HasComment("ShoppingCartItem ShoppingCartMasterId")
            .HasColumnOrder(8)
            .IsRequired(required: true);

        #endregion Fields

        #region Relationships

        shoppingCartBuilder.HasMany(shoppingCart => shoppingCart.ShoppingCartItems)
            .WithOne(shoppingCartItem => shoppingCartItem.ShoppingCart)
            .HasForeignKey(shoppingCartItem => shoppingCartItem.ShoppingCartId)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion Relationships

        #region Seeder

        #endregion Seeder

        #endregion Rule properties
    }
}