using Example.Ecommerce.Domain.Entities.Parametrization;
using Example.Ecommerce.Persistence.Seeders.Parametrization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Persistence.Configurations.Parametrization
{
    public class IdentificationTypeConfiguration : IEntityTypeConfiguration<IdentificationTypeEntity>
    {
        public void Configure(EntityTypeBuilder<IdentificationTypeEntity> identificationTypeBuilder)
        {
            #region Rule properties

            #region General config

            identificationTypeBuilder.ToTable(name: "IdentificationType", schema: "Parametrization");

            #endregion General config

            #region Fields

            identificationTypeBuilder.Property(identificationType => identificationType.Id)
                .HasColumnName("Id")
                .HasComment("Table Id")
                .ValueGeneratedOnAdd()
                .HasColumnOrder(1)
                .IsRequired(required: true);

            identificationTypeBuilder.Property(identificationType => identificationType.Name)
                .HasColumnName("Name")
                .HasComment("Identification Type Name")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .HasColumnOrder(2)
                .IsUnicode(false)
                .IsRequired(required: true);

            identificationTypeBuilder.Property(identificationType => identificationType.Description)
                .HasColumnName("Description")
                .HasComment("Identification Type Description")
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .HasColumnOrder(3)
                .IsUnicode(false)
                .IsRequired(required: true);

            #endregion Fields

            #region Relationships

            // Primary Key
            identificationTypeBuilder.HasKey(identificationType => identificationType.Id);

            identificationTypeBuilder.HasMany(identificationType => identificationType.HeadLines)
                .WithOne(headLine => headLine.IdentificationType)
                .HasForeignKey(headLine => headLine.IdentificationTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            identificationTypeBuilder.HasMany(identificationType => identificationType.Beneficiaries)
                .WithOne(beneficiary => beneficiary.IdentificationType)
                .HasForeignKey(beneficiary => beneficiary.IdentificationTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion Relationships

            #region Seeder

            identificationTypeBuilder.AddSeeder();

            #endregion Seeder

            #endregion Rule properties
        }
    }
}
