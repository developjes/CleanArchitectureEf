using Example.Ecommerce.Application.Interface.Persistence.Connector.Ef;
using Example.Ecommerce.Application.Interface.Persistence.ExternalServices;
using Example.Ecommerce.Persistence.Contexts;
using Example.Ecommerce.Persistence.ExternalServices;
using Example.Ecommerce.Persistence.Interceptors;
using Example.Ecommerce.Persistence.Repositories.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Ecommerce.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();

            services.AddSingleton<DapperApplicationDbContext>();
            services.AddDbContext<EfApplicationDbContext>(options =>
            {
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.EnableSensitiveDataLogging();
                options.UseSqlServer(
                    configuration.GetConnectionString("NorthwindConnection")!,
                    builder =>
                    {
                        builder.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
                        builder.MigrationsAssembly(typeof(EfApplicationDbContext).Assembly.FullName);
                        builder.UseNetTopologySuite();
                    }
                );
            });

            services.AddScoped<IEfUnitOfWork, EfUnitOfWork>();
            services.AddTransient<IRestService, RestService>();

            return services;
        }
    }
}