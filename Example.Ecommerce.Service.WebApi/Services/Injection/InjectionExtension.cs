using Example.Ecommerce.Service.WebApi.Services.AntiforgeryCookie;

namespace Example.Ecommerce.Service.WebApi.Services.Injection;

public static class InjectionExtension
{
    public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(configuration);
        services.AddTransient<AntiforgeryCookieFilterAttribute>();

        return services;
    }
}