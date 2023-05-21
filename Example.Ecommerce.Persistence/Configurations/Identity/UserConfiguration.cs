using Example.Ecommerce.Domain.Entities.Identity;
using Example.Ecommerce.Persistence.Seeders.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Persistence.Configurations.Identity;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> userBuilder)
    {
        #region Rule properties

        #region Fields

        userBuilder.Property(user => user.Id).HasMaxLength(36);

        userBuilder.Property(user => user.NormalizedUserName).HasMaxLength(90);

        #endregion Fields

        #region Seeder

        userBuilder.AddSeeder();

        #endregion Seeder

        #endregion Rule properties
    }
}