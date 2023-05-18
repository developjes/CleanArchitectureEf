using Microsoft.EntityFrameworkCore;
using Example.Ecommerce.Persistence.Interceptors;
using System.Reflection;
using Example.Ecommerce.Domain.Entities.Parametrization;
using Example.Ecommerce.Persistence.Configurations.Common;
using Example.Ecommerce.Domain.Entities.Petition;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Example.Ecommerce.Persistence.Contexts.SqlServer
{
    /*
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<StateEntity>? StateEntity { get; set; }
        public virtual DbSet<IdentificationTypeEntity>? IdentificationTypeEntity { get; set; }

        public virtual DbSet<PetitionEntity>? PetitionEntity { get; set; }
        public virtual DbSet<HeadLineEntity>? HeadLineEntity { get; set; }
        public virtual DbSet<BeneficiaryEntity>? BeneficiaryEntity { get; set; }

        private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor
        ) : base(options) =>
            _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ChangeTracker.AutoDetectChangesEnabled = true;
            //ChangeTracker.LazyLoadingEnabled = false;

            optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder) =>
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            await base.SaveChangesAsync(cancellationToken);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.AddAuditFieldsConfiguration();
            base.OnModelCreating(modelBuilder);
        }
    }
    */
}