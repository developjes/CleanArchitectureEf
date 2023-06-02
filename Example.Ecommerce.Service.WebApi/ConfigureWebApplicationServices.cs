using Example.Ecommerce.Service.WebApi.Middlewares;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Example.Ecommerce.Service.WebApi;

public static class ConfigureWebApplicationServices
{
    public static IApplicationBuilder AddWebApplicationServices(this WebApplication app)
    {
        #region Develop Elements

        if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
        {
            #region Static files

            app.UseStaticFiles();

            app.UseDefaultFiles();

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
                c.InjectStylesheet($"/{Path.Combine("css", "SwaggerCustom.css")}");
                c.SupportedSubmitMethods(
                    SubmitMethod.Get, SubmitMethod.Post, SubmitMethod.Put, SubmitMethod.Patch,
                    SubmitMethod.Delete, SubmitMethod.Head
                );
            });

            #endregion SwaggerUI App Config
        }

        #endregion Develop Elements

        #region Production elements

        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        else { app.UseHsts(); }

        #endregion Production elements

        #region WebApplicationBuilders

        //app.UseStatusCodePages();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseMiddleware<SecurityHeadersMiddleware>();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseCors("policyApiEcommerce");

        app.UseRequestLocalization();

        app.MapControllers();

        #endregion WebApplicationBuilders

        return app;
    }
}