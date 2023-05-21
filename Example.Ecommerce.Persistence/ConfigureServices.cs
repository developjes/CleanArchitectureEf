using Example.Ecommerce.Application.Interface.Persistence.Connector.Dapper;
using Example.Ecommerce.Application.Interface.Persistence.Connector.Ef;
using Example.Ecommerce.Application.UseCases.Models.Token;
using Example.Ecommerce.Persistence.Contexts;
using Example.Ecommerce.Persistence.Interceptors;
using Example.Ecommerce.Persistence.Repositories.Dapper;
using Example.Ecommerce.Persistence.Repositories.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Ecommerce.Persistence;

public static class ConfigureServices
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region Interceptor

        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        #endregion Interceptor

        #region DbContext

        const string connectionStringJsonName = "NorthwindConnection";

        #region Dapper

        services.AddSingleton(_ => new DapperApplicationDbContext(configuration, connectionStringJsonName));

        #endregion Dapper

        #region EF

        services.AddDbContext<EfApplicationDbContext>(options =>
        {
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            options.EnableSensitiveDataLogging();
            options.UseSqlServer(
                configuration.GetConnectionString(connectionStringJsonName)!,
                builder =>
                {
                    builder.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
                    builder.MigrationsAssembly(typeof(EfApplicationDbContext).Assembly.FullName);
                    builder.UseNetTopologySuite();
                }
            );
        });

        #endregion EF

        #endregion DbContext

        #region UnitOfWork

        services.AddScoped<IDapperUnitOfWork, DapperUnitOfWork>();

        services.AddScoped<IEfUnitOfWork, EfUnitOfWork>();
        services.AddScoped(typeof(IEfBaseRepository<>), typeof(EfBaseRepository<>));

        #endregion UnitOfWork

        #region JWT Config

        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

        #endregion

        return services;
    }
}