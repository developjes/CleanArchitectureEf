using Example.Ecommerce.Persistence.Seeders.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Persistence.Configurations.Identity;

public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> identityRoleBuilder)
    {
        #region Rule properties

        #region Fields

        identityRoleBuilder.Property(identityRole => identityRole.Id).HasMaxLength(36);

        identityRoleBuilder.Property(identityRole => identityRole.NormalizedName).HasMaxLength(90);

        #endregion Fields

        #region Seeder

        identityRoleBuilder.AddSeeder();

        #endregion Seeder

        #endregion Rule properties
    }
}