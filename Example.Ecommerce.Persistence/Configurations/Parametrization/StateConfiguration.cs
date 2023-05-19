using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Example.Ecommerce.Domain.Entities.Parametrization;

namespace Example.Ecommerce.Persistence.Configurations.Parametrization;

public sealed class StateConfiguration : IEntityTypeConfiguration<StateEntity>
{
    public void Configure(EntityTypeBuilder<StateEntity> stateBuilder)
    {
        #region Rule properties

        #region General config

        stateBuilder.ToTable(name: "State", schema: "Parametrization");

        #endregion General config

        #region Fields

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

        // Unique Index
        stateBuilder.HasIndex(state => state.Name).IsUnique();

        #endregion Relationships

        #region Seeder

        #endregion Seeder

        #endregion Rule properties
    }
}