using Example.Ecommerce.Domain.Entities.Ecommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Persistence.Configurations.Ecommerce;

public sealed class OrderItemConfiguration : IEntityTypeConfiguration<OrderItemEntity>
{
    public void Configure(EntityTypeBuilder<OrderItemEntity> orderItemBuilder)
    {
        #region Rule properties

        #region General config

        orderItemBuilder.ToTable(name: "OrderItem", schema: "Ecommerce");

        #endregion General config

        #region Fields

        orderItemBuilder.Property(orderItem => orderItem.Price)
            .HasColumnName("Price")
            .HasComment("OrderItem price")
            .HasColumnType("decimal")
            .HasPrecision(10, 2)
            .HasColumnOrder(2)
            .IsRequired(required: true);

        orderItemBuilder.Property(orderItem => orderItem.Amount)
            .HasColumnName("Amount")
            .HasComment("OrderItem Amount")
            .HasColumnType("int")
            .HasColumnOrder(3)
            .IsRequired(required: true);

        orderItemBuilder.Property(orderItem => orderItem.ProductName)
            .HasColumnName("ProductName")
            .HasComment("OrderItem ProductName")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .HasColumnOrder(4)
            .IsUnicode(false)
            .IsRequired(required: true);

        orderItemBuilder.Property(orderItem => orderItem.ImageUrl)
            .HasColumnName("ImageUrl")
            .HasComment("orderItem ImageUrl")
            .HasColumnType("varchar")
            .HasMaxLength(4000)
            .HasColumnOrder(5)
            .IsUnicode(false)
            .IsRequired(required: true);

        orderItemBuilder.Property(product => product.ProductItemId)
            .HasColumnName("ProductItemId")
            .HasComment("orderItem ProductItemId")
            .HasColumnType("int")
            .HasColumnOrder(6)
            .IsRequired(required: true);

        orderItemBuilder.Property(product => product.OrderId)
            .HasColumnName("OrderId")
            .HasComment("OrderIdItem ForeignKey Order Table")
            .HasColumnType("int")
            .HasColumnOrder(7)
            .IsRequired(required: true);

        orderItemBuilder.Property(product => product.ProductId)
            .HasColumnName("ProductId")
            .HasComment("OrderIdItem ForeignKey Product Table")
            .HasColumnType("int")
            .HasColumnOrder(8)
            .IsRequired(required: true);

        #endregion Fields

        #region Relationships

        orderItemBuilder.HasOne(orderItem => orderItem.Order)
            .WithMany(order => order.OrderItems)
            .HasForeignKey(orderItem => orderItem.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        orderItemBuilder.HasOne(orderItem => orderItem.Product)
            .WithMany(product => product.OrderItems)
            .HasForeignKey(orderItem => orderItem.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        #endregion Relationships

        #region Seeder

        #endregion Seeder

        #endregion Rule properties
    }
}