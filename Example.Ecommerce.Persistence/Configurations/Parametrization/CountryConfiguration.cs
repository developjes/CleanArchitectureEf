using Example.Ecommerce.Domain.Entities.Parametrization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Persistence.Configurations.Parametrization;

public sealed class CountryConfiguration : IEntityTypeConfiguration<CountryEntity>
{
    public void Configure(EntityTypeBuilder<CountryEntity> countryBuilder)
    {
        #region Rule properties

        #region General config

        countryBuilder.ToTable(name: "Country", schema: "Parametrization");

        #endregion General config

        #region Fields

        countryBuilder.Property(country => country.Name)
            .HasColumnName("Name")
            .HasComment("Country Name")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .HasColumnOrder(2)
            .IsUnicode(false)
            .IsRequired(required: true);

        countryBuilder.Property(country => country.Iso2)
            .HasColumnName("Iso2")
            .HasComment("Country Iso2")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .HasColumnOrder(3)
            .IsUnicode(false)
            .IsRequired(required: true);

        countryBuilder.Property(country => country.Iso3)
            .HasColumnName("Iso3")
            .HasComment("Country Iso3")
            .HasColumnType("nvarchar")
            .HasMaxLength(100)
            .HasColumnOrder(4)
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