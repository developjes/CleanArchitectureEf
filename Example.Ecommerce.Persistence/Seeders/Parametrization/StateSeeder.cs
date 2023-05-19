using Example.Ecommerce.Domain.Entities.Parametrization;
using Example.Ecommerce.Domain.Enums.Parametrization;
using Example.Ecommerce.Transversal.Common.Extension;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;

namespace Example.Ecommerce.Persistence.Seeders.Parametrization;

public static class StateSeeder
{
    public static EntityTypeBuilder<StateEntity> AddSeeder(this EntityTypeBuilder<StateEntity> stateEntity)
    {
        stateEntity.HasData(new HashSet<StateEntity>()
        {
            new()
            {
                Id = (int)EAllStates.Inactive,
                Name = nameof(EAllStates.Inactive),
                Description = ((DescriptionAttribute?)Attribute.GetCustomAttribute(
                    EAllStates.Inactive.GetType().GetField(nameof(EAllStates.Inactive))!,
                    typeof(DescriptionAttribute))
                )!.Description,
                CreateAt = DateTime.Now.DateTimeZoneInfo(),
                CreatedBy = "System"
            },
            new()
            {
                Id = (int)EAllStates.Active,
                Name= nameof(EAllStates.Active),
                Description = ((DescriptionAttribute?)Attribute.GetCustomAttribute(
                    EAllStates.Active.GetType().GetField(nameof(EAllStates.Active))!,
                    typeof(DescriptionAttribute))
                )!.Description,
                CreateAt = DateTime.Now.DateTimeZoneInfo(),
                CreatedBy = "System"
            }
        });

        return stateEntity;
    }
}