using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Example.Ecommerce.Persistence.Configurations.Common;

public static class AuditConfiguration
{
    public static ModelBuilder AddAuditFieldsConfiguration(this ModelBuilder modelBuilder)
    {
        foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (IMutableProperty property in entityType.GetProperties()
                .Where(p => p.ClrType.Equals(typeof(DateTime)) && p.Name.Contains("At")))
            {
                if (property.Name.Equals("CreateAt", StringComparison.OrdinalIgnoreCase))
                {
                    property.SetColumnName("CreateAt");
                    property.SetComment("Fecha de creacion del registro");
                    property.IsNullable = false;
                }

                else if (property.Name.Equals("UpdateAt", StringComparison.OrdinalIgnoreCase))
                {
                    property.SetColumnName("UpdateAt");
                    property.SetComment("Fecha de actualizacion del registro");
                    property.IsNullable = true;
                }
            }

            foreach (IMutableProperty property in entityType.GetProperties()
                .Where(p => p.ClrType.Equals(typeof(string)) && p.Name.Contains("By")))
            {
                if (property.Name.Equals("CreatedBy", StringComparison.OrdinalIgnoreCase))
                {
                    property.SetColumnName("CreatedBy");
                    property.SetComment("Usuario que crea el registro");
                    property.IsNullable = false;
                }

                else if (property.Name.Equals("LastModifiedBy", StringComparison.OrdinalIgnoreCase))
                {
                    property.SetColumnName("LastModifiedBy");
                    property.SetComment("Usuario que por ultima vez actualizo el registro");
                    property.IsNullable = true;
                }
            }
        }

        return modelBuilder;
    }
}