using Example.Ecommerce.Domain.Entities.Petition;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetTopologySuite.Geometries;

namespace Example.Ecommerce.Persistence.Seeders.Petition
{
    public static class HeadLineSeeder
    {
        public static EntityTypeBuilder<HeadLineEntity> AddSeeder(this EntityTypeBuilder<HeadLineEntity> headLineEntity)
        {
            headLineEntity.HasData(new HashSet<HeadLineEntity>()
            {
                new() {
                    Id = 1,
                    IdentificationNumber = "1143953449",
                    FirstName = "Jhon",
                    SecondName = "Eddier",
                    FirstLastName = "Solarte",
                    SecondLastName = "Vasquez",
                    BirthDate = new DateTime(1993, 2, 23),
                    IdentificationTypeId = 1,
                    Location = new Point(18.4839233, -69.9388777)
                },
                new() {
                    Id = 2,
                    IdentificationNumber = "1063811659",
                    FirstName = "Paola",
                    SecondName = "Andrea",
                    FirstLastName = "Diaz",
                    SecondLastName = "Manzano",
                    BirthDate = new DateTime(1991, 12, 11),
                    IdentificationTypeId = 3,
                    Location = new Point(18.4839233, -69.9388777)
                },
                new() {
                    Id = 3,
                    IdentificationNumber = "1111111111",
                    FirstName = "Araceli",
                    SecondName = null,
                    FirstLastName = "Diaz",
                    SecondLastName = null,
                    BirthDate = new DateTime(1969, 5, 25),
                    IdentificationTypeId = 3,
                    Location = new Point(18.4839233, -69.9388777)
                }
            });

            return headLineEntity;
        }
    }
}
