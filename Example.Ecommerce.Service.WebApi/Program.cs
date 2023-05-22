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

#region Validator and serializators

builder.Services.AddControllers(x =>
{
    x.Filters.AddService(typeof(AntiforgeryCookieResultFilter));
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

builder.Services.AddResponseCompression();

#endregion compresion

#region Asyncronous process

builder.Services.Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = true);
builder.Services.Configure<IISServerOptions>(options => options.AllowSynchronousIO = true);

#endregion Asyncronous process

#region ApiExplorer

builder.Services.AddEndpointsApiExplorer();

#endregion ApiExplorer

#region Feature

builder.Services.AddFeature(builder.Configuration);

#endregion

#region Authentication

builder.Services.AddIdentityAuthentication(builder.Configuration);

#endregion

#region Versioning

builder.Services.AddVersioning();

#endregion

#region Dependency Injection

builder.Services.AddInjection(builder.Configuration);

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

else { app.UseHsts(); }

#endregion Production elements

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("policyApiEcommerce");

app.UseRequestLocalization();

app.MapControllers();

app.Run();

#endregion

public partial class Program { }