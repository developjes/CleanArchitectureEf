using Example.Ecommerce.Application.Validator.Behaviors;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Example.Ecommerce.Application.UseCases;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        #region Mapper

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        #endregion Mapper

        #region Fluent Validator

        services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies(), ServiceLifetime.Scoped);
        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

        #endregion Fluent Validator

        #region Add MediaTr

        services.AddMediatR(handlers => handlers.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        #endregion Add MediaTr

        #region Behaviors

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));

        #endregion  Behaviors

        return services;
    }
}