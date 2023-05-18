using Example.Ecommerce.Domain.Entities.Petition;
using Example.Ecommerce.Domain.Enums.Parametrization;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Persistence.Seeders.Petition
{
    public static class PetitionSeeder
    {
        public static EntityTypeBuilder<PetitionEntity> AddSeeder(this EntityTypeBuilder<PetitionEntity> petitionEntity)
        {
            petitionEntity.HasData(new HashSet<PetitionEntity>()
            {
                new() {
                    Id = 1,
                    Radicate = "202",
                    Expired = false,
                    HeadLineId = 1,
                    StateId = EState.Active
                },
                new() {
                    Id = 2,
                    Radicate = "2355",
                    Expired = false,
                    HeadLineId = 2,
                    StateId = EState.Active
                },
                new() {
                    Id = 3,
                    Radicate = "321",
                    Expired = false,
                    HeadLineId = 2,
                    StateId = EState.Inactive
                }
            });

            return petitionEntity;
        }
    }
}