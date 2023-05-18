using Example.Ecommerce.Domain.Entities.Petition;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Example.Ecommerce.Persistence.Seeders.Petition;

namespace Example.Ecommerce.Persistence.Configurations.Petition
{
    public class HeadLineConfiguration : IEntityTypeConfiguration<HeadLineEntity>
    {
        public void Configure(EntityTypeBuilder<HeadLineEntity> headLineBuilder)
        {
            #region Rule properties

            #region General config

            headLineBuilder.ToTable(name: "HeadLine", schema: "northwindconnect");

            #endregion General config

            #region Fields

            headLineBuilder.Property(headLine => headLine.Id)
                .HasColumnName("Id")
                .HasComment("Table Id")
                .ValueGeneratedOnAdd()
                .HasColumnOrder(1)
                .IsRequired(required: true);

            headLineBuilder.Property(headLine => headLine.IdentificationNumber)
                .HasColumnName("IdentificationNumber")
                .HasComment("Head Line Identification Number")
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .HasColumnOrder(2)
                .IsUnicode(false)
                .IsRequired(required: true);

            headLineBuilder.Property(headLine => headLine.FirstName)
                .HasColumnName("FirstName")
                .HasComment("Head Line First Name")
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .HasColumnOrder(3)
                .IsUnicode(false)
                .IsRequired(required: true);

            headLineBuilder.Property(headLine => headLine.SecondName)
                .HasColumnName("SecondName")
                .HasComment("Head Line Second Name")
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .HasColumnOrder(4)
                .IsUnicode(false)
                .IsRequired(required: false);

            headLineBuilder.Property(headLine => headLine.FirstLastName)
                .HasColumnName("FirstLastName")
                .HasComment("Head Line First Last Name")
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .HasColumnOrder(5)
                .IsUnicode(false)
                .IsRequired(required: true);

            headLineBuilder.Property(headLine => headLine.SecondLastName)
                .HasColumnName("SecondLastName")
                .HasComment("Head Line Second Last Name")
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .HasColumnOrder(6)
                .IsUnicode(false)
                .IsRequired(required: false);

            headLineBuilder.Ignore(headLine => headLine.FullName);

            headLineBuilder.Property(headLine => headLine.BirthDate)
                .HasColumnName("Birthdate")
                .HasComment("Head Line Birthdate")
                .HasColumnType("date")
                .HasColumnOrder(7)
                .IsRequired(required: true);

            headLineBuilder.Property(headLine => headLine.Location)
                .HasColumnName("Location")
                .HasComment("Head Line Location")
                .HasColumnType("Point")
                .IsRequired(required: true);

            headLineBuilder.Ignore(headLine => headLine.AgeYearsRunning);
            headLineBuilder.Ignore(headLine => headLine.AgeMonthsRunning);
            headLineBuilder.Ignore(headLine => headLine.AgeDaysRunning);

            headLineBuilder.Property(headLine => headLine.IdentificationTypeId)
                .HasColumnName("IdentificationTypeId")
                .HasComment("ForeignKey Identification Type Table")
                .HasColumnType("int")
                .HasColumnOrder(8)
                .IsRequired(required: true);

            #endregion Fields

            #region Relationships

            // Primary Key
            headLineBuilder.HasKey(petition => petition.Id);

            headLineBuilder.HasMany(headLine => headLine.Petitions)
                .WithOne(petition => petition.HeadLine)
                .HasForeignKey(petition => petition.HeadLineId)
                .OnDelete(DeleteBehavior.Restrict);

            headLineBuilder.HasOne(headLine => headLine.IdentificationType)
                .WithMany(identificationType => identificationType.HeadLines)
                .HasForeignKey(headLine => headLine.IdentificationTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            headLineBuilder.HasMany(headLine => headLine.Beneficiaries)
                .WithOne(beneficiary => beneficiary.HeadLine)
                .HasForeignKey(beneficiary => beneficiary.HeadLineId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion Relationships

            #region Seeder

            headLineBuilder.AddSeeder();

            #endregion Seeder

            #endregion Rule properties
        }
    }
}
