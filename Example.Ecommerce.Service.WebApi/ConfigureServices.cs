using Example.Ecommerce.Service.WebApi.Services.AntiforgeryCookie;
using Example.Ecommerce.Service.WebApi.Services.Authentication;
using Example.Ecommerce.Service.WebApi.Services.Converters;
using Example.Ecommerce.Service.WebApi.Services.Cors;
using Example.Ecommerce.Service.WebApi.Services.Injection;
using Example.Ecommerce.Service.WebApi.Services.Swagger;
using Example.Ecommerce.Service.WebApi.Services.Versioning;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Text.Json.Serialization;

namespace Example.Ecommerce.Service.WebApi;

public static class ConfigureServices
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region Antiforgery Cross-Site

        services.AddAntiforgery(opts => opts.HeaderName = "X-XSRF-Token");

        #endregion

        #region Validator and serializators

        services.AddControllers(x =>
        {
            x.Filters.AddService(typeof(AntiforgeryCookieFilterAttribute));
            x.EnableEndpointRouting = false;
            x.ModelMetadataDetailsProviders.Clear();
            x.ModelValidatorProviders.Clear();
            x.RespectBrowserAcceptHeader = true;
        })
        .AddJsonOptions(opt =>
        {
            opt.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
            opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            opt.JsonSerializerOptions.Converters.Add(new ByteArrayConverter());

            opt.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            opt.JsonSerializerOptions.IncludeFields = true;
            opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            opt.JsonSerializerOptions.MaxDepth = 0;
        });

        #endregion Validator and serializators

        #region compresion

        services.AddResponseCompression();

        #endregion compresion

        #region Asyncronous server process

        services.Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = true);
        services.Configure<IISServerOptions>(options => options.AllowSynchronousIO = true);

        #endregion Asyncronous server process

        #region ApiExplorer

        services.AddEndpointsApiExplorer();

        #endregion ApiExplorer

        #region Feature

        services.AddCors(configuration);

        #endregion

        #region Authentication

        services.AddIdentityAuthentication(configuration);

        #endregion

        #region Versioning

        services.AddVersioning();

        #endregion

        #region Dependency Injection

        services.AddInjection(configuration);

        #endregion

        #region Swagger

        services.AddSwagger();

        #endregion

        return services;
    }
}