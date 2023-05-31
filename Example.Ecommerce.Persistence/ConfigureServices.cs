using Example.Ecommerce.Application.Interface.Identity;
using Example.Ecommerce.Application.Interface.Persistence.Connector.Dapper;
using Example.Ecommerce.Application.Interface.Persistence.Connector.Ef;
using Example.Ecommerce.Application.Interface.Persistence.EmailSendGrid;
using Example.Ecommerce.Application.Interface.Persistence.ImageCloudinary;
using Example.Ecommerce.Application.Interface.Persistence.RabbitMq;
using Example.Ecommerce.Persistence.Contexts;
using Example.Ecommerce.Persistence.EventBus;
using Example.Ecommerce.Persistence.ExternalServices.EmailSengrid;
using Example.Ecommerce.Persistence.ExternalServices.ImageCloudinary;
using Example.Ecommerce.Persistence.Interceptors;
using Example.Ecommerce.Persistence.Models.Configuration;
using Example.Ecommerce.Persistence.Repositories.Dapper;
using Example.Ecommerce.Persistence.Repositories.EfCore;
using Example.Ecommerce.Persistence.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

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

        #region Services

        services.AddTransient<IAuthService, AuthService>();

        #endregion Services

        #region External Services

        services.AddTransient<IManageImageService, ManageImageService>();
        services.AddTransient<IManagementEmailSengridService, ManagementEmailSengridService>();

        #endregion External Services

        #region RabbitMq

        services.AddScoped<IEventBus, EventBusRabbitMQ>(sp => {
            IServiceScopeFactory scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
            IOptions<RabbitMqSettings>? optionsFactory = sp.GetService<IOptions<RabbitMqSettings>>();

            return new EventBusRabbitMQ(sp.GetService<IMediator>()!, scopeFactory, optionsFactory!);
        });

        #endregion RabbitMq

        #region Config

        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));
        services.Configure<SendGridSettings>(configuration.GetSection("SendGridConfiguration"));
        services.Configure<StripeSettings>(configuration.GetSection("StripeSettings"));
        services.Configure<RabbitMqSettings>(configuration.GetSection("RabbitMqSettings"));
        #endregion

        return services;
    }
}