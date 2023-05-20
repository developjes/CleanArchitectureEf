using Example.Ecommerce.Domain.Entities.Ecommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Persistence.Configurations.Ecommerce;

public sealed class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> ordeBuilder)
    {
        #region Rule properties

        #region General config

        ordeBuilder.ToTable(name: "Order", schema: "Ecommerce");

        #endregion General config

        ordeBuilder.Property(order => order.BuyerName)
            .HasColumnName("BuyerName")
            .HasComment("Order BuyerName")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .HasColumnOrder(2)
            .IsUnicode(false)
            .IsRequired(required: true);

        ordeBuilder.Property(order => order.BuyerUsername)
            .HasColumnName("BuyerUsername")
            .HasComment("Order BuyerUsername")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .HasColumnOrder(3)
            .IsUnicode(false)
            .IsRequired(required: true);

        ordeBuilder.Property(order => order.SubTotal)
            .HasColumnName("SubTotal")
            .HasComment("Order SubTotal")
            .HasColumnType("decimal")
            .HasPrecision(10, 2)
            .HasColumnOrder(4)
            .IsRequired(required: true);

        ordeBuilder.Property(order => order.Total)
            .HasColumnName("Total")
            .HasComment("Order Total")
            .HasColumnType("decimal")
            .HasPrecision(10, 2)
            .HasColumnOrder(5)
            .IsRequired(required: true);

        ordeBuilder.Property(order => order.Tax)
            .HasColumnName("Tax")
            .HasComment("Order Tax")
            .HasColumnType("decimal")
            .HasPrecision(10, 2)
            .HasColumnOrder(6)
            .IsRequired(required: true);

        ordeBuilder.Property(order => order.ShippingPrice)
            .HasColumnName("ShippingPrice")
            .HasComment("Order ShippingPrice")
            .HasColumnType("decimal")
            .HasPrecision(10, 2)
            .HasColumnOrder(7)
            .IsRequired(required: true);

        ordeBuilder.Property(order => order.ClientSecret)
            .HasColumnName("ClientSecret")
            .HasComment("OrderItem ClientSecret")
            .HasColumnType("nvarchar")
            .HasMaxLength(4000)
            .HasColumnOrder(8)
            .IsUnicode(false)
            .IsRequired(required: true);

        ordeBuilder.Property(order => order.StripeApiKey)
            .HasColumnName("StripeApiKey")
            .HasComment("Order StripeApiKey")
            .HasColumnType("nvarchar")
            .HasMaxLength(4000)
            .HasColumnOrder(9)
            .IsUnicode(false)
            .IsRequired(required: true);

        ordeBuilder.Property(order => order.PaymentIntentId)
            .HasColumnName("PaymentIntentId")
            .HasComment("OrderItem PaymentIntentId")
            .HasColumnType("nvarchar")
            .HasMaxLength(4000)
            .HasColumnOrder(10)
            .IsUnicode(false)
            .IsRequired(required: true);

        ordeBuilder.Ignore(order => order.StateId);
        ordeBuilder.Property<int>("_stateId")
            .HasColumnName("StateId")
            .HasComment("Order ForeignKey State Table")
            .HasColumnType("int")
            .HasColumnOrder(11)
            .IsRequired(required: true);

        #endregion Rule properties

        #region Relationships

        ordeBuilder.HasOne(order => order.State)
            .WithMany(state => state.Orders)
            .HasForeignKey("_stateId")
            .HasConstraintName("FK_Order_State_StateId")
            .OnDelete(DeleteBehavior.Restrict);

        ordeBuilder.OwnsOne(o => o.OrderAddress, x => x.WithOwner());

        #endregion Relationships
    }
}