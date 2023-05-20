using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Persistence.Configurations.Identity;

public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> identityRoleBuilder)
    {
        #region Rule properties

        #region General config

        identityRoleBuilder.ToTable(name: "IdentityRole", schema: "Auth");

        #endregion General config

        #region Fields

        identityRoleBuilder.Property(identityRole => identityRole.Id).HasMaxLength(36);

        identityRoleBuilder.Property(identityRole => identityRole.NormalizedName).HasMaxLength(90);

        #endregion Fields

        #endregion Rule properties
    }
}