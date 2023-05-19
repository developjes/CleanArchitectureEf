using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Example.Ecommerce.Persistence.Configurations.Common
{
    public static class AuditConfiguration
    {
        public static ModelBuilder AddAuditFieldsConfiguration(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (IMutableProperty property in entityType.GetProperties().Where(p => p.ClrType.Equals(typeof(DateTime))))
                {
                    if (property.Name.Equals("CreateAt", StringComparison.CurrentCultureIgnoreCase))
                    {
                        property.SetColumnName("CreateAt");
                        property.SetComment("Fecha de creacion del registro");
                        property.IsNullable = false;
                    }

                    else if (property.Name.Equals("UpdateAt", StringComparison.CurrentCultureIgnoreCase))
                    {
                        property.SetColumnName("UpdateAt");
                        property.SetComment("Fecha de actualizacion del registro");
                        property.IsNullable = true;
                    }
                }
            }

            return modelBuilder;
        }
    }
}