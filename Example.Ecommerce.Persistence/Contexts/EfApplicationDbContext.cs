using Example.Ecommerce.Domain.Entities.Parametrization;
using Example.Ecommerce.Persistence.Configurations.Common;
using Example.Ecommerce.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace Example.Ecommerce.Persistence.Contexts;

public class EfApplicationDbContext : DbContext
{
    #region DbSet Entities

    public virtual DbSet<StateEntity>? StateEntity { get; set; }

    #endregion DbSet Entities

    #region Interceptors

    private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

    #endregion Interceptors

    #region Constructor

    public EfApplicationDbContext(
        DbContextOptions<EfApplicationDbContext> options,
        AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor
    ) : base(options)
    {
        ChangeTracker.AutoDetectChangesEnabled = true;
        ChangeTracker.LazyLoadingEnabled = false;
        _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
    }

    #endregion Constructor

    #region Methods

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.AddPrimaryKeyConfiguration();
        modelBuilder.AddAuditFieldsConfiguration();

        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await base.SaveChangesAsync(cancellationToken);

    #endregion Methods
}