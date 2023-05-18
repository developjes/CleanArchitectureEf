using Example.Ecommerce.Domain.Entities.Parametrization;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.Ecommerce.Persistence.Seeders.Parametrization
{
    public static class IdentificationTypeSeeder
    {
        public static EntityTypeBuilder<IdentificationTypeEntity> AddSeeder(this EntityTypeBuilder<IdentificationTypeEntity> identificationTypeEntity)
        {
            identificationTypeEntity.HasData(new HashSet<IdentificationTypeEntity>()
            {
                new() { Id = 1, Name = "Cedula de ciudadania", Description = "Documento de identidad nacional" },
                new() { Id = 2, Name = "Tarjeta de identidad", Description = "Documento de identidad nacional" },
                new() { Id = 3, Name = "Cedula de extrageria", Description = "Documento de identidad internacional" }
            });

            return identificationTypeEntity;
        }
    }
}
