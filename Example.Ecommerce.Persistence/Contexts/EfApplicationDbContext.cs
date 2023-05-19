using Microsoft.EntityFrameworkCore;
using Example.Ecommerce.Persistence.Interceptors;
using System.Reflection;
using Example.Ecommerce.Domain.Entities.Parametrization;
using Example.Ecommerce.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddAuditFieldsConfiguration();
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await base.SaveChangesAsync(cancellationToken);

    #endregion Methods
}