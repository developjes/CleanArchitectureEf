using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Example.Ecommerce.Persistence.Configurations.Common;

public static class PrimaryKeyConfiguration
{
    public static ModelBuilder AddPrimaryKeyConfiguration(this ModelBuilder modelBuilder)
    {
        foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (IMutableProperty property in entityType.GetProperties()
                .Where(p => (p.Name.Equals("Id") || p.Name.Equals($"{entityType.Name}Id")) && p.ClrType.Equals(typeof(int))))
            {
                property.SetColumnName(property.Name);
                property.SetColumnType("int");
                property.SetComment("Table Id");
                property.SetIdentityIncrement(1);
                property.SetColumnOrder(1);
                property.IsNullable = false;

                entityType.SetPrimaryKey(property);
            }
        }

        return modelBuilder;
    }
}