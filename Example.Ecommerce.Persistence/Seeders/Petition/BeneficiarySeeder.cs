using Example.Ecommerce.Domain.Entities.Petition;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Persistence.Seeders.Petition
{
    public static class BeneficiarySeeder
    {
        public static EntityTypeBuilder<BeneficiaryEntity> AddSeeder(this EntityTypeBuilder<BeneficiaryEntity> beneficiaryEntity)
        {
            beneficiaryEntity.HasData(new HashSet<BeneficiaryEntity>()
            {
                new() {
                    Id = 1,
                    IdentificationNumber = "31179933",
                    FirstName = "Francy",
                    SecondName = "Eliana",
                    FirstLastName = "Vasquez",
                    SecondLastName = "Rodriguez",
                    IdentificationTypeId = 1,
                    HeadLineId = 1
                },
                new() {
                    Id = 2,
                    IdentificationNumber = "1063811659",
                    FirstName = "Araceli",
                    FirstLastName = "Diaz",
                    SecondLastName = "Manzano",
                    IdentificationTypeId = 1,
                    HeadLineId = 2
                }
            });

            return beneficiaryEntity;
        }
    }
}
