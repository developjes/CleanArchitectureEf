using Example.Ecommerce.Domain.Helper.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Persistence.Seeders.Identity;

public static class IdentityRoleSeeder
{
    public static EntityTypeBuilder<IdentityRole> AddSeeder(this EntityTypeBuilder<IdentityRole> identityRole)
    {
        identityRole.HasData(new HashSet<IdentityRole>()
        {
            new()
            {
                Id = "fab4fac1-c546-41de-aebc-a14da6895711",
                Name = AppRole.Admin,
                NormalizedName = AppRole.Admin,
                ConcurrencyStamp = "1"
            },
            new()
            {
                Id = "c7b013f0-5201-4317-abd8-c211f91b7330",
                Name = AppRole.Hr,
                NormalizedName = "Human Resource",
                ConcurrencyStamp = "2"
            }
        });

        return identityRole;
    }
}