using Example.Ecommerce.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Persistence.Seeders.Identity;

public static class UserSeeder
{
    public static EntityTypeBuilder<UserEntity> AddSeeder(this EntityTypeBuilder<UserEntity> userBuilder)
    {
        HashSet<UserEntity> users = new()
        {
            new()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                Name = "Jhon",
                LastName = "Solarte",
                Email = "developjes@gmail.com",
                NormalizedEmail = "developjes@gmail.com",
                UserName = "JES",
                NormalizedUserName = "JES",
                PhoneNumber = "1234567890",
                AvatarUrl = "https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/vaxidrez.jpg?alt=media&token=14a28860-d149-461e-9c25-9774d7ac1b24",
                EmailConfirmed = true,
                ConcurrencyStamp = "2f720227-3b1a-4f93-b903-f58b7c6e5417",
                PasswordHash = "AQAAAAEAACcQAAAAEMxOmA+z7VusdsgQWgF0DqYEx0psTSZttrV4crjA8qgJ9c3Hku1Rx3Fk44ARiyyDnA==",
                SecurityStamp = "099fcf83-9992-4d1e-bccd-3c70debabe25"
            },
            new()
            {
                Id = "b74ddd14-6340-4840-95c2-db579863843e",
                Name = "Juan",
                LastName = "Perez",
                Email = "juan.perez@gmail.com",
                UserName = "juan.perez",
                NormalizedUserName = "JUAN",
                PhoneNumber = "98563434534",
                AvatarUrl = "https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/avatar-1.webp?alt=media&token=58da3007-ff21-494d-a85c-25ffa758ff6d",
                EmailConfirmed = true,
                ConcurrencyStamp = "864adedf-0c91-4e64-a64f-fd7c6d0f45d4",
                PasswordHash = "AQAAAAEAACcQAAAAEBtqzKN9NgbXF3g01MmMaxGodZHIjDBj4pIQL1kxlFFQOFOnv8CsPXGkxGS3NWfT5w==",
                SecurityStamp = "183032ff-489e-4b6e-abdc-f89a9610690d"
            }
        };

        /*
        PasswordHasher<UserEntity> passwordHasher
        foreach (UserEntity user in users)
            user.PasswordHash = passwordHasher.HashPassword(user, "user*123")
        */

        userBuilder.HasData(users);

        return userBuilder;
    }
}