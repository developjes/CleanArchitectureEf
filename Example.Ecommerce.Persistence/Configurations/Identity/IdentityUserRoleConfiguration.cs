using Example.Ecommerce.Persistence.Seeders.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Persistence.Configurations.Identity;

public sealed class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> identityUserRoleBuilder)
    {
        #region Rule properties

        #region Fields

        #endregion Fields

        #region Seeder

        identityUserRoleBuilder.AddSeeder();

        #endregion Seeder

        #endregion Rule properties
    }
}