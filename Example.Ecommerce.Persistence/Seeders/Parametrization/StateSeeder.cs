using Example.Ecommerce.Domain.Entities.Parametrization;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Persistence.Seeders.Parametrization;

public static class StateSeeder
{
    public static EntityTypeBuilder<StateEntity> AddSeeder(this EntityTypeBuilder<StateEntity> stateEntity)
    {
        stateEntity.HasData(new HashSet<StateEntity>()
        {
            new() { Id = 1, Name= "Inactive", Description = "Inactivo" },
            new() { Id = 2, Name= "Active", Description = "Activo" }
        });

        return stateEntity;
    }
}