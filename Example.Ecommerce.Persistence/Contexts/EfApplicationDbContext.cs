﻿using Example.Ecommerce.Domain.Entities.Identity;
using Example.Ecommerce.Persistence.Configurations.Common;
using Example.Ecommerce.Persistence.Interceptors;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Example.Ecommerce.Persistence.Contexts;

public class EfApplicationDbContext : IdentityDbContext<UserEntity>
{
    #region Constructor

    public EfApplicationDbContext(DbContextOptions<EfApplicationDbContext> options) : base(options)
    {
        ChangeTracker.AutoDetectChangesEnabled = true;
        ChangeTracker.LazyLoadingEnabled = false;
    }

    #endregion Constructor

    #region Methods

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.AddInterceptors(new AuditableEntitySaveChangesInterceptor());

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.AddPrimaryKeyConfiguration();
        builder.AddAuditFieldsConfiguration();

        base.OnModelCreating(builder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await base.SaveChangesAsync(cancellationToken);

    #endregion Methods
}