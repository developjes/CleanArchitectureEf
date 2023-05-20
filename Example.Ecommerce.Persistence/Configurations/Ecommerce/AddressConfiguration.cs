using Example.Ecommerce.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Persistence.Configurations.Ecommerce;

public sealed class AddressConfiguration : IEntityTypeConfiguration<AddressEntity>
{
    public void Configure(EntityTypeBuilder<AddressEntity> addressBuilder)
    {
        #region Rule properties

        #region General config

        addressBuilder.ToTable(name: "Address", schema: "Auth");

        #endregion General config

        #region Fields

        addressBuilder.Property(address => address.Address)
            .HasColumnName("Address")
            .HasComment("Address address")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .HasColumnOrder(2)
            .IsUnicode(false)
            .IsRequired(required: true);

        addressBuilder.Property(address => address.City)
            .HasColumnName("City")
            .HasComment("Address City")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .HasColumnOrder(3)
            .IsUnicode(false)
            .IsRequired(required: true);

        addressBuilder.Property(address => address.Department)
            .HasColumnName("Department")
            .HasComment("Address Department")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .HasColumnOrder(4)
            .IsUnicode(false)
            .IsRequired(required: true);

        addressBuilder.Property(address => address.PostalCode)
            .HasColumnName("PostalCode")
            .HasComment("Address PostalCode")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .HasColumnOrder(5)
            .IsUnicode(false)
            .IsRequired(required: true);

        addressBuilder.Property(address => address.Username)
            .HasColumnName("Username")
            .HasComment("Address Username")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .HasColumnOrder(6)
            .IsUnicode(false)
            .IsRequired(required: true);

        addressBuilder.Property(address => address.Country)
            .HasColumnName("Country")
            .HasComment("Address Country")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .HasColumnOrder(7)
            .IsUnicode(false)
            .IsRequired(required: true);

        #endregion Fields

        #region Relationships

        #endregion Relationships

        #region Seeder

        #endregion Seeder

        #endregion Rule properties
    }
}