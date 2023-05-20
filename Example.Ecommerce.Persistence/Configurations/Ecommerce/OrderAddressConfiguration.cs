using Example.Ecommerce.Domain.Entities.Ecommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Persistence.Configurations.Ecommerce;

public sealed class OrderAddressConfiguration : IEntityTypeConfiguration<OrderAddressEntity>
{
    public void Configure(EntityTypeBuilder<OrderAddressEntity> orderAddressBuilder)
    {
        #region Rule properties

        #region General config

        orderAddressBuilder.ToTable(name: "OrderAddress", schema: "Ecommerce");

        #endregion General config

        #region Fields

        orderAddressBuilder.Property(address => address.Address)
            .HasColumnName("Address")
            .HasComment("OrderAddress address")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .HasColumnOrder(2)
            .IsUnicode(false)
            .IsRequired(required: true);

        orderAddressBuilder.Property(address => address.City)
            .HasColumnName("City")
            .HasComment("OrderAddress City")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .HasColumnOrder(3)
            .IsUnicode(false)
            .IsRequired(required: true);

        orderAddressBuilder.Property(address => address.Department)
            .HasColumnName("Department")
            .HasComment("OrderAddress Department")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .HasColumnOrder(4)
            .IsUnicode(false)
            .IsRequired(required: true);

        orderAddressBuilder.Property(address => address.PostalCode)
            .HasColumnName("PostalCode")
            .HasComment("OrderAddress PostalCode")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .HasColumnOrder(5)
            .IsUnicode(false)
            .IsRequired(required: true);

        orderAddressBuilder.Property(address => address.Username)
            .HasColumnName("Username")
            .HasComment("OrderAddress Username")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .HasColumnOrder(6)
            .IsUnicode(false)
            .IsRequired(required: true);

        orderAddressBuilder.Property(address => address.Country)
            .HasColumnName("Country")
            .HasComment("OrderAddress Country")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .HasColumnOrder(7)
            .IsUnicode(false)
            .IsRequired(required: true);

        #endregion Fields

        #endregion Rule properties
    }
}