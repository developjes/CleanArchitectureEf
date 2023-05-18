using Example.Ecommerce.Domain.Entities.Common;
using Example.Ecommerce.Transversal.Common.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Example.Ecommerce.Persistence.Interceptors
{
    public class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            UpdateAuditableEntities(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private static void UpdateAuditableEntities(DbContext? context)
        {
            if (context is null) return;

            foreach (EntityEntry<BaseAuditableEntity> entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added :
                        entry.Entity.CreateAt = DateTime.Now.DateTimeZoneInfo();
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdateAt = DateTime.Now.DateTimeZoneInfo();
                        break;
                }
            }
        }
    }
}