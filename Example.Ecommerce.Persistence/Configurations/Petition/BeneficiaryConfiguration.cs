using Example.Ecommerce.Domain.Entities.Petition;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Example.Ecommerce.Persistence.Seeders.Petition;

namespace Example.Ecommerce.Persistence.Configurations.Petition
{
    public class BeneficiaryConfiguration : IEntityTypeConfiguration<BeneficiaryEntity>
    {
        public void Configure(EntityTypeBuilder<BeneficiaryEntity> beneficiaryBuilder)
        {
            #region Rule properties

            #region General config

            beneficiaryBuilder.ToTable(name: "Beneficiary", schema: "Petition");

            #endregion General config

            #region Fields

            beneficiaryBuilder.Property(beneficiary => beneficiary.Id)
                .HasColumnName("Id")
                .HasComment("Table Id")
                .ValueGeneratedOnAdd()
                .HasColumnOrder(1)
                .IsRequired(required: true);

            beneficiaryBuilder.Property(headLine => headLine.IdentificationNumber)
                .HasColumnName("IdentificationNumber")
                .HasComment("Head Line Identification Number")
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .HasColumnOrder(2)
                .IsUnicode(false)
                .IsRequired(required: true);

            beneficiaryBuilder.Property(beneficiary => beneficiary.FirstName)
                .HasColumnName("FirstName")
                .HasComment("Beneficiary First Name")
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .HasColumnOrder(3)
                .IsUnicode(false)
                .IsRequired(required: true);

            beneficiaryBuilder.Property(beneficiary => beneficiary.SecondName)
                .HasColumnName("SecondName")
                .HasComment("Beneficiary Second Name")
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .HasColumnOrder(4)
                .IsUnicode(false)
                .IsRequired(required: false);

            beneficiaryBuilder.Property(beneficiary => beneficiary.FirstLastName)
                .HasColumnName("FirstLastName")
                .HasComment("Beneficiary First Last Name")
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .HasColumnOrder(5)
                .IsUnicode(false)
                .IsRequired(required: true);

            beneficiaryBuilder.Property(beneficiary => beneficiary.SecondLastName)
                .HasColumnName("SecondLastName")
                .HasComment("Beneficiary Second Last Name")
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .HasColumnOrder(6)
                .IsUnicode(false)
                .IsRequired(required: false);

            beneficiaryBuilder.Property(beneficiary => beneficiary.IdentificationTypeId)
                .HasColumnName("IdentificationTypeId")
                .HasComment("ForeignKey Identification Type Table")
                .HasColumnType("int")
                .HasColumnOrder(7)
                .IsRequired(required: true);

            beneficiaryBuilder.Property(beneficiary => beneficiary.HeadLineId)
                .HasColumnName("HeadLineIdId")
                .HasComment("ForeignKey HeadLine Table")
                .HasColumnOrder(8)
                .IsRequired(required: true);

            #endregion Fields

            #region Relationships

            // Primary Key
            beneficiaryBuilder.HasKey(beneficiary => beneficiary.Id);

            beneficiaryBuilder.HasOne(beneficiary => beneficiary.IdentificationType)
                .WithMany(identificationType => identificationType.Beneficiaries)
                .HasForeignKey(identificationType => identificationType.IdentificationTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            beneficiaryBuilder.HasOne(beneficiary => beneficiary.HeadLine)
                .WithMany(headLine => headLine.Beneficiaries)
                .HasForeignKey(beneficiary => beneficiary.HeadLineId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion Relationships

            #region Seeder

            beneficiaryBuilder.AddSeeder();

            #endregion Seeder

            #endregion Rule properties
        }
    }
}
