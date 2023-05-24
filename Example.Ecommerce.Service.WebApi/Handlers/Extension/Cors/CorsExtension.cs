namespace Example.Ecommerce.Service.WebApi.Handlers.Extension.Cors;

public static class CorsExtension
{
    public static IServiceCollection AddFeature(this IServiceCollection services, IConfiguration configuration)
    {
        #region cors

        IConfiguration corsOrigin = configuration.GetSection("CorsOrigin");
        string localUrl = corsOrigin.GetSection("Local").Value ?? string.Empty;

        const string myPolicy = "policyApiEcommerce";
        services.AddCors(options =>
            options.AddPolicy(myPolicy, builder =>
                builder.SetIsOriginAllowedToAllowWildcardSubdomains()
                    .WithOrigins(localUrl!)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
            )
        );

        #endregion

        return services;
    }
}