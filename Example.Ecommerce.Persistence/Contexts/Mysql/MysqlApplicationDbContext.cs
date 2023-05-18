using Example.Ecommerce.Domain.Entities.Parametrization;
using Example.Ecommerce.Domain.Entities.Petition;
using Example.Ecommerce.Persistence.Contexts.SqlServer;
using Example.Ecommerce.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Example.Ecommerce.Persistence.Configurations.Common;

namespace Example.Ecommerce.Persistence.Contexts.Mysql
{
    public class MysqlApplicationDbContext : DbContext
    {
        public virtual DbSet<StateEntity>? StateEntity { get; set; }
        public virtual DbSet<IdentificationTypeEntity>? IdentificationTypeEntity { get; set; }

        public virtual DbSet<PetitionEntity>? PetitionEntity { get; set; }
        public virtual DbSet<HeadLineEntity>? HeadLineEntity { get; set; }
        public virtual DbSet<BeneficiaryEntity>? BeneficiaryEntity { get; set; }

        private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;

        public MysqlApplicationDbContext(
            DbContextOptions<MysqlApplicationDbContext> options,
            AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor
        ) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = true;
            ChangeTracker.LazyLoadingEnabled = false;

            Database.SetCommandTimeout(150000);

            _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder) =>
            configurationBuilder.Properties<DateTime>().HaveColumnType("datetime");

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            await base.SaveChangesAsync(cancellationToken);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci").HasCharSet("utf8mb4");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.AddAuditFieldsConfiguration();
            base.OnModelCreating(modelBuilder);
        }
    }
}