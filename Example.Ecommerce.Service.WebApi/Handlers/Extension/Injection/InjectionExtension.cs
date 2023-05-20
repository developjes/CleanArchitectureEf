using Example.Ecommerce.Service.WebApi.Handlers.Extension.AntiforgeryCookie;
using Example.Ecommerce.Transversal.Common.Interface;
using Example.Ecommerce.Transversal.Logging;

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