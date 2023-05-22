using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Persistence.Seeders.Identity;

public static class IdentityUserRolesSeeder
{
    public static EntityTypeBuilder<IdentityUserRole<string>> AddSeeder(
        this EntityTypeBuilder<IdentityUserRole<string>> identityUserRole
    )
    {
        identityUserRole.HasData(new HashSet<IdentityUserRole<string>>()
        {
            new()
            {
                RoleId = "fab4fac1-c546-41de-aebc-a14da6895711",
                UserId = "b74ddd14-6340-4840-95c2-db12554843e5"
            },
            new()
            {
                RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330",
                UserId = "b74ddd14-6340-4840-95c2-db579863843e"
            }
        });

        return identityUserRole;
    }
}