using Example.Ecommerce.Domain.Entities.Parametrization;
using Example.Ecommerce.Persistence.Seeders.Parametrization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            .HasMaxLength(100)
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

        stateBuilder.HasMany(state => state.Products)
            .WithOne(product => product.State)
            .HasForeignKey("_stateId")
            .HasConstraintName("FK_Product_State_StateId")
            .OnDelete(DeleteBehavior.Restrict);

        stateBuilder.HasMany(state => state.Orders)
            .WithOne(order => order.State)
            .HasForeignKey("_stateId")
            .HasConstraintName("FK_Order_State_StateId")
            .OnDelete(DeleteBehavior.Restrict);

        #endregion Relationships

        #region Seeder

        stateBuilder.AddSeeder();

        #endregion Seeder

        #endregion Rule properties
    }
}