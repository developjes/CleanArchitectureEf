using Example.Ecommerce.Service.WebApi.Services.Swagger.Filters;
using Example.Ecommerce.Service.WebApi.Services.Swagger.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Example.Ecommerce.Service.WebApi.Services.Swagger;

public static class SwaggerExtension
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOption>();

        // Register the Swagger generator, defining 1 or more Swagger documents

        services.AddSwaggerGen(c =>
        {
            OpenApiSecurityScheme securityScheme = new()
            {
                Name = "Authorization",
                Description = "Enter JWT Bearer token **_only_**",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Reference = new() { Id = JwtBearerDefaults.AuthenticationScheme, Type = ReferenceType.SecurityScheme }
            };

            c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
            c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
            c.OperationFilter<SwaggerFormMultipartFilter>();
            c.AddSecurityRequirement(new OpenApiSecurityRequirement() { { securityScheme, new List<string>() } });
            c.UseInlineDefinitionsForEnums();
            c.UseOneOfForPolymorphism();
            c.UseAllOfToExtendReferenceSchemas();
            c.SupportNonNullableReferenceTypes();
            c.DescribeAllParametersInCamelCase();
            c.EnableAnnotations(enableAnnotationsForInheritance: true, enableAnnotationsForPolymorphism: true);
            c.IgnoreObsoleteActions();
            c.IgnoreObsoleteProperties();
            c.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.HttpMethod}");
            c.CustomOperationIds(apiDesc => apiDesc.TryGetMethodInfo(out MethodInfo methodInfo) ? methodInfo.Name : null);

            // Set the comments path for the Swagger JSON and UI.
            string xmlPath = GetXmlDocumentationFileFor(Assembly.GetExecutingAssembly());
            if (File.Exists(xmlPath))
                c.IncludeXmlComments(xmlPath);

            c.TagActionsBy(api => new[] { api.GroupName });
            c.DocInclusionPredicate((_, __) => true);
        });

        return services;
    }

    private static string GetXmlDocumentationFileFor(Assembly assembly)
    {
        string documentationFile = $"{assembly.GetName().Name}.xml";
        return Path.Combine(AppContext.BaseDirectory, documentationFile);
    }
}