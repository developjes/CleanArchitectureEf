using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;

namespace Example.Ecommerce.Persistence.Configurations.Common;

public static class PrimaryKeyConfiguration
{
    public static ModelBuilder AddPrimaryKeyConfiguration(this ModelBuilder modelBuilder)
    {
        foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (IMutableProperty property in entityType.GetProperties()
                .Where(p => p.ClrType.Equals(typeof(int)) && p.Name.Equals("Id")))
            {
                property.SetColumnName("Id");
                property.SetColumnType("int");
                property.SetIdentityIncrement(1);
                property.SetComment("Table Id");
                property.SetColumnOrder(1);
                property.IsNullable = true;
            }
        }

        return modelBuilder;
    }
}