using Example.Ecommerce.Application.Interface.Persistence;
using Example.Ecommerce.Application.Interface.Persistence.ExternalServices;
using Example.Ecommerce.Application.Interface.Persistence.Parametrization;
using Example.Ecommerce.Application.Interface.Persistence.Petition;
using Example.Ecommerce.Persistence.Contexts.Mysql;
using Example.Ecommerce.Persistence.Contexts.SqlServer;
using Example.Ecommerce.Persistence.ExternalServices;
using Example.Ecommerce.Persistence.Interceptors;
using Example.Ecommerce.Persistence.Repositories;
using Example.Ecommerce.Persistence.Repositories.Parametrization;
using Example.Ecommerce.Persistence.Repositories.Petition;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Example.Ecommerce.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();

            services.AddDbContext<MysqlApplicationDbContext>(options =>
            {
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.EnableSensitiveDataLogging();
                options.UseMySql(
                    configuration.GetConnectionString("MySqlConnection")!,
                    ServerVersion.Parse("8.0.33-mysql"),
                    builder =>
                    {
                        builder.UseNetTopologySuite();
                        builder.SchemaBehavior(MySqlSchemaBehavior.Ignore);
                        builder.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
                        builder.MigrationsAssembly(typeof(MysqlApplicationDbContext).Assembly.FullName);
                    }
                );
            });

            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<IIdentificationTypeRepository, IdentificationTypeRepository>();

            services.AddScoped<IPetitionRepository, PetitionRepository>();
            services.AddScoped<IHeadLineRepository, HeadLineRepository>();
            services.AddScoped<IBeneficiaryRepository, BeneficiaryRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRestService, RestService>();

            return services;
        }
    }
}