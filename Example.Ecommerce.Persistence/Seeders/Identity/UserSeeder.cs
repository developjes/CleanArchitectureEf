using Example.Ecommerce.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Identity;

namespace Example.Ecommerce.Persistence.Seeders.Identity;

public static class UserSeeder
{
    public static EntityTypeBuilder<UserEntity> AddSeeder(this EntityTypeBuilder<UserEntity> userEntity)
    {
        HashSet<UserEntity> users = new()
        {
            new()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                Name = "Jhon",
                LastName = "Solarte",
                Email = "developjes@gmail.com",
                UserName = "JES",
                PhoneNumber = "1234567890",
                AvatarUrl = "https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/vaxidrez.jpg?alt=media&token=14a28860-d149-461e-9c25-9774d7ac1b24"
            },
            new()
            {
                Id = "b74ddd14-6340-4840-95c2-db579863843e1",
                Name = "Juan",
                LastName = "Perez",
                Email = "juan.perez@gmail.com",
                UserName = "juan.perez",
                PhoneNumber = "98563434534",
                AvatarUrl = "https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/avatar-1.webp?alt=media&token=58da3007-ff21-494d-a85c-25ffa758ff6d"
            }
        };

        foreach (UserEntity user in users)
        {
            PasswordHasher<UserEntity> passwordHasher = new();
            passwordHasher.HashPassword(user, "Admin*123");
        }

        userEntity.HasData(users);

        return userEntity;
    }
}