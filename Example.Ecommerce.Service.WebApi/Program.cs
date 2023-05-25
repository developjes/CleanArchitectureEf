using Example.Ecommerce.Application.UseCases;
using Example.Ecommerce.Persistence;
using Example.Ecommerce.Service.WebApi;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.SwaggerUI;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

#region Builder

#region Add presentation project

builder.Services.AddPresentationServices(builder.Configuration);

#endregion Add presentation project

#region Add application project

builder.Services.AddApplicationServices();

#endregion Add application project

#region Add application project

builder.Services.AddApplicationServices();

#endregion Add application project

#region Add persistence project

builder.Services.AddPersistenceServices(builder.Configuration);

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