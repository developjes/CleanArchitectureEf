using Example.Ecommerce.Application.UseCases;
using Example.Ecommerce.Persistence;
using Example.Ecommerce.Service.WebApi.Handlers.Extension.AntiforgeryCookie;
using Example.Ecommerce.Service.WebApi.Handlers.Extension.Authentication;
using Example.Ecommerce.Service.WebApi.Handlers.Extension.Converters;
using Example.Ecommerce.Service.WebApi.Handlers.Extension.Feature;
using Example.Ecommerce.Service.WebApi.Handlers.Extension.Injection;
using Example.Ecommerce.Service.WebApi.Handlers.Extension.Swagger;
using Example.Ecommerce.Service.WebApi.Handlers.Extension.Versioning;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text.Json.Serialization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

#region Builder

#region Antiforgery Cross-Site

builder.Services.AddAntiforgery(opts => opts.HeaderName = "X-XSRF-Token");

#endregion

builder.Services.AddControllers(x =>
{
    x.Filters.AddService(typeof(AntiforgeryCookieResultFilter));
    x.EnableEndpointRouting = false;
    x.ModelMetadataDetailsProviders.Clear();
    x.ModelValidatorProviders.Clear();
    x.RespectBrowserAcceptHeader = true;
    //x.OutputFormatters.Add(new XmlSerializerOutputFormatter());
    //x.InputFormatters.Add(new XmlSerializerInputFormatter(x));
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
})
//.AddXmlSerializerFormatters()
;

builder.Services.AddResponseCompression();

builder.Services.Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = true);
builder.Services.Configure<IISServerOptions>(options => options.AllowSynchronousIO = true);

builder.Services.AddEndpointsApiExplorer();

#region Feature

builder.Services.AddFeature(builder.Configuration);

#endregion

#region Authentication

builder.Services.AddAuthentication(builder.Configuration);

#endregion

#region Versioning

builder.Services.AddVersioning();

#endregion

#region Dependency Injection

builder.Services.AddInjection(builder.Configuration);

#endregion

#region Session

builder.Services.AddSession();

#endregion

#region HealthCheck

//builder.Services.AddHealthCheck(builder.Configuration)

#endregion

#region Swagger

builder.Services.AddSwagger();

#endregion

#region Add persistence project

builder.Services.AddPersistenceServices(builder.Configuration);

#endregion

#region Add application project

builder.Services.AddApplicationServices();

#endregion

#endregion Builder

// Configure the HTTP request pipeline.
WebApplication app = builder.Build();

#region App

#region Develop Elements

if (app.Environment.IsDevelopment())
{
    #region Static files

    app.UseStaticFiles();

    #endregion

    #region Exception page

    app.UseDeveloperExceptionPage();

    #endregion

    #region Swagger App Config

    app.UseSwagger(c => c.SerializeAsV2 = false);

    #endregion

    #region SwaggerUI App Config

    app.UseSwaggerUI(c =>
    {
        // build a swagger endpoint for each discovered API version
        IApiVersionDescriptionProvider provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        for (int i = 0; i < provider.ApiVersionDescriptions.Count; i++)
        {
            ApiVersionDescription description = provider.ApiVersionDescriptions[i];
            c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }

        c.DocumentTitle = "My Swagger UI";
        c.RoutePrefix = "api-docs";
        c.DisplayRequestDuration();
        c.DisplayOperationId();
        c.EnableFilter();
        c.EnableDeepLinking();
        c.ShowExtensions();
        c.ShowCommonExtensions();
        c.EnableValidator();
        c.DefaultModelsExpandDepth(-1);
        c.DocExpansion(DocExpansion.List);
        c.InjectStylesheet(Path.Combine("css", "SwaggerCustom.css"));
        c.SupportedSubmitMethods(
            SubmitMethod.Get, SubmitMethod.Post, SubmitMethod.Put, SubmitMethod.Patch, SubmitMethod.Delete, SubmitMethod.Head
        );
    });

    #endregion SwaggerUI App Config
}

#endregion Develop Elements

#region Production elements

else
{
    app.UseHsts();
    /*
    app.UseHealthChecksUI(config =>
    {
        config.UIPath = "/hc-ui";
        config.AddCustomStylesheet("./wwwroot/css/dotnet.css");
    });
    app.MapHealthChecks("/health", new()
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
        AllowCachingResponses = false
    });
    */
}

#endregion Production elements

// Cancel request
//app.UseMiddleware<TaskCanceledMiddleware>();
// Scan Headers: https://securityheaders.com/
//app.UseMiddleware<SecurityHeadersMiddleware>();
// Global Exception
//app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseCors("policyApiEcommerce");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseRequestLocalization();
app.UseSession();
app.MapControllers();

app.Run();

#endregion

public partial class Program { }