using Example.Ecommerce.Service.WebApi.Handlers.Extension.AntiforgeryCookie;

namespace Example.Ecommerce.Service.WebApi.Handlers.Extension.Injection;

public static class InjectionExtension
{
    public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(configuration);
        services.AddTransient<AntiforgeryCookieResultFilter>();

        return services;
    }
}