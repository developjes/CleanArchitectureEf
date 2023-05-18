using Example.Ecommerce.Application.Interface.UseCases.Parametrization;
using Example.Ecommerce.Application.Interface.UseCases.Petition;
using Example.Ecommerce.Application.UseCases.Parametrization;
using Example.Ecommerce.Application.UseCases.Petition;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Example.Ecommerce.Application.UseCases
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IStatesApplication, StatesApplication>();
            services.AddScoped<IHeadLinesApplication, HeadLinesApplication>();
            services.AddScoped<IGoRestPostApplication, GoRestPostApplication>();

            return services;
        }
    }
}