using Example.Ecommerce.Domain.Entities.Petition;
using Example.Ecommerce.Persistence.Seeders.Petition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Persistence.Configurations.Petition
{
    public class PetitionConfiguration : IEntityTypeConfiguration<PetitionEntity>
    {
        public void Configure(EntityTypeBuilder<PetitionEntity> petitionBuilder)
        {
            #region Rule properties

            #region General config

            petitionBuilder.ToTable(name: "Petition", schema: "Petition");

            #endregion General config

            #region Fields

            petitionBuilder.Property(petition => petition.Id)
                .HasColumnName("Id")
                .HasComment("Table Id")
                .ValueGeneratedOnAdd()
                .HasColumnOrder(1)
                .IsRequired(required: true);

            petitionBuilder.Property(petition => petition.Radicate)
                .HasColumnName("Radicate")
                .HasComment("Petition Radicate")
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .HasColumnOrder(2)
                .IsUnicode(false)
                .IsRequired(required: false);

            petitionBuilder.Property(petition => petition.Expired)
                .HasColumnName("Expired")
                .HasComment("Petition Expired")
                .HasColumnType("bit")
                .HasColumnOrder(3)
                .IsRequired(required: true);

            petitionBuilder.Property(petition => petition.HeadLineId)
                .HasColumnName("HeadLineId")
                .HasComment("ForeignKey HeadLine Table")
                .HasColumnOrder(4)
                .IsRequired(required: true);

            petitionBuilder.Ignore(petition => petition.StateId);
            petitionBuilder.Property<int>("_stateId")
                .HasColumnName("StateId")
                .HasComment("ForeignKey State Table")
                .HasColumnType("int")
                .HasColumnOrder(5)
                .IsRequired(required: true);

            #endregion Fields

            #region Constrains

            // Primary Key
            petitionBuilder.HasKey(petition => petition.Id);

            petitionBuilder.HasOne(petition => petition.HeadLine)
                .WithMany(headLine => headLine.Petitions)
                .HasForeignKey(petition => petition.HeadLineId)
                .OnDelete(DeleteBehavior.Restrict);

            // FK using shadow property
            petitionBuilder.HasOne(petition => petition.State)
                .WithMany(state => state.Petitions)
                .HasForeignKey("_stateId")
                .HasConstraintName("FK_Petition_State_StateId")
                .OnDelete(DeleteBehavior.Restrict);

            #endregion Constrains

            #region Seeder

            petitionBuilder.AddSeeder();

            #endregion Seeder

            #endregion Rule properties
        }
    }
}
