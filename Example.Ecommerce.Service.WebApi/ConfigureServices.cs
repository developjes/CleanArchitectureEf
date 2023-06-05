using Example.Ecommerce.Service.WebApi.Filters;
using Example.Ecommerce.Service.WebApi.Services.AntiforgeryCookie;
using Example.Ecommerce.Service.WebApi.Services.Authentication;
using Example.Ecommerce.Service.WebApi.Services.Converters;
using Example.Ecommerce.Service.WebApi.Services.Cors;
using Example.Ecommerce.Service.WebApi.Services.Injection;
using Example.Ecommerce.Service.WebApi.Services.Swagger;
using Example.Ecommerce.Service.WebApi.Services.Versioning;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Swashbuckle.AspNetCore.Filters;
using System.IO.Compression;
using System.Reflection;
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
            x.Filters.Add<ApiExceptionFilterAttribute>();
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

        services.AddResponseCompression(opt => {
            opt.EnableForHttps = true;
            opt.Providers.Add<BrotliCompressionProvider>();
            opt.Providers.Add<GzipCompressionProvider>();
        });

        services.Configure<BrotliCompressionProviderOptions>(options => options.Level = CompressionLevel.Fastest);
        services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.SmallestSize);

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

        #endregion Feature

        #region Authentication

        services.AddIdentityAuthentication(configuration);

        #endregion Authentication

        #region Versioning

        services.AddVersioning();

        #endregion Versioning

        #region Dependency Injection

        services.AddInjection(configuration);

        #endregion Dependency Injection

        #region Swagger

        services.AddSwagger();
        services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
        services.AddFluentValidationRulesToSwagger();

        #endregion Swagger

        #region Forms limit

        services.Configure<FormOptions>(options => options.MultipartBodyLengthLimit = 100000000);

        #endregion Forms limit

        return services;
    }
}