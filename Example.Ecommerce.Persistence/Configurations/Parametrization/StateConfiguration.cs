using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Example.Ecommerce.Domain.Entities.Parametrization;
using Example.Ecommerce.Persistence.Seeders.Parametrization;

namespace Example.Ecommerce.Persistence.Configurations.Parametrization
{
    public sealed class StateConfiguration : IEntityTypeConfiguration<StateEntity>
    {
        public void Configure(EntityTypeBuilder<StateEntity> stateBuilder)
        {
            #region Rule properties

            #region General config

            stateBuilder.ToTable(name: "State", schema: "northwindconnect");

            #endregion General config

            #region Fields

            stateBuilder.Property(state => state.Id)
                .HasColumnName("Id")
                .HasComment("Table Id")
                .ValueGeneratedOnAdd()
                .HasColumnOrder(1)
                .IsRequired(required: true);

            stateBuilder.Property(state => state.Name)
                .HasColumnName("Name")
                .HasComment("State Name")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .HasColumnOrder(2)
                .IsUnicode(false)
                .IsRequired(required: true);

            stateBuilder.Property(state => state.Description)
                .HasColumnName("Description")
                .HasComment("State Description")
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .HasColumnOrder(3)
                .IsUnicode(false)
                .IsRequired(required: true);

            #endregion Fields

            #region Relationships

            // Primary Key
            stateBuilder.HasKey(state => state.Id);

            // Unique Index
            stateBuilder.HasIndex(state => state.Name).IsUnique();

            stateBuilder.HasMany(state => state.Petitions)
                .WithOne(petition => petition.State)
                .HasForeignKey("_stateId")
                .HasConstraintName("FK_Petition_State_StateId")
                .OnDelete(DeleteBehavior.Restrict);

            #endregion Relationships

            #region Seeder

            stateBuilder.AddSeeder();

            #endregion Seeder

            #endregion Rule properties
        }
    }
}