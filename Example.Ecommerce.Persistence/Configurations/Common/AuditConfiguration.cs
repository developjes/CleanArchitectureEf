using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Example.Ecommerce.Persistence.Configurations.Common;

public static class AuditConfiguration
{
    public static ModelBuilder AddAuditFieldsConfiguration(this ModelBuilder modelBuilder)
    {
        foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
        {
            byte counterColumns = (byte)entityType.GetProperties().Count();

            foreach (IMutableProperty property in entityType.GetProperties()
                .Where(p => p.Name.EndsWith("At") && p.ClrType.Equals(typeof(DateTime))))
            {
                if (property.Name.Equals("CreateAt", StringComparison.OrdinalIgnoreCase))
                {
                    property.SetColumnName("CreateAt");
                    property.SetComment("Fecha de creacion del registro");
                    property.IsNullable = false;
                    property.SetColumnOrder(counterColumns - 3);
                }

                else if (property.Name.Equals("UpdateAt", StringComparison.OrdinalIgnoreCase))
                {
                    property.SetColumnName("UpdateAt");
                    property.SetComment("Fecha de actualizacion del registro");
                    property.IsNullable = true;
                    property.SetColumnOrder(counterColumns - 1);
                }
            }

            foreach (IMutableProperty property in entityType.GetProperties()
                .Where(p => p.Name.EndsWith("By") && p.ClrType.Equals(typeof(string))))
            {
                if (property.Name.Equals("CreatedBy", StringComparison.OrdinalIgnoreCase))
                {
                    property.SetColumnName("CreatedBy");
                    property.SetComment("Usuario que crea el registro");
                    property.SetColumnOrder(counterColumns);
                    property.SetColumnType("varchar");
                    property.SetMaxLength(100);
                    property.IsNullable = false;
                }

                else if (property.Name.Equals("LastModifiedBy", StringComparison.OrdinalIgnoreCase))
                {
                    property.SetColumnName("LastModifiedBy");
                    property.SetComment("Usuario que por ultima vez actualizo el registro");
                    property.SetColumnType("varchar");
                    property.SetMaxLength(100);
                    property.IsNullable = true;
                }
            }
        }

        return modelBuilder;
    }
}