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
                Name = "Admin",
                ConcurrencyStamp = "1",
                NormalizedName = "Admin"
            },
            new()
            {
                Id = "c7b013f0-5201-4317-abd8-c211f91b7330",
                Name = "HR",
                ConcurrencyStamp = "2",
                NormalizedName = "Human Resource"
            }
        });

        return identityRole;
    }
}