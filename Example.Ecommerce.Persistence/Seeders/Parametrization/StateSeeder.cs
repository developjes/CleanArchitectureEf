using Example.Ecommerce.Domain.Entities.Parametrization;
using Example.Ecommerce.Domain.Enums.Parametrization;
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
                CreateAt = new DateTime(2023, 05, 19),
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
                CreateAt = new DateTime(2023, 05, 19),
                CreatedBy = "System"
            },
            new()
            {
                Id = (int)EAllStates.Pending,
                Name= nameof(EAllStates.Pending),
                Description = ((DescriptionAttribute?)Attribute.GetCustomAttribute(
                    EAllStates.Pending.GetType().GetField(nameof(EAllStates.Pending))!,
                    typeof(DescriptionAttribute))
                )!.Description,
                CreateAt = new DateTime(2023, 05, 19),
                CreatedBy = "System"
            },
            new()
            {
                Id = (int)EAllStates.Completed,
                Name= nameof(EAllStates.Completed),
                Description = ((DescriptionAttribute?)Attribute.GetCustomAttribute(
                    EAllStates.Completed.GetType().GetField(nameof(EAllStates.Completed))!,
                    typeof(DescriptionAttribute))
                )!.Description,
                CreateAt = new DateTime(2023, 05, 19),
                CreatedBy = "System"
            },
            new()
            {
                Id = (int)EAllStates.Sent,
                Name= nameof(EAllStates.Sent),
                Description = ((DescriptionAttribute?)Attribute.GetCustomAttribute(
                    EAllStates.Sent.GetType().GetField(nameof(EAllStates.Sent))!,
                    typeof(DescriptionAttribute))
                )!.Description,
                CreateAt = new DateTime(2023, 05, 19),
                CreatedBy = "System"
            },
            new()
            {
                Id = (int)EAllStates.Error,
                Name= nameof(EAllStates.Error),
                Description = ((DescriptionAttribute?)Attribute.GetCustomAttribute(
                    EAllStates.Error.GetType().GetField(nameof(EAllStates.Error))!,
                    typeof(DescriptionAttribute))
                )!.Description,
                CreateAt = new DateTime(2023, 05, 19),
                CreatedBy = "System"
            }
        });

        return stateEntity;
    }
}