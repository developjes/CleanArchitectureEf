using Example.Ecommerce.Application.UseCases.Features.Ecommerce.Products.Commands.Create;
using Example.Ecommerce.Application.Validator.Behaviors;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        services.AddFluentValidationAutoValidation(config => config.DisableDataAnnotationsValidation = true).AddFluentValidationClientsideAdapters();

        services.AddValidatorsFromAssemblyContaining<CreateProductCommandValidator>();

        #endregion Fluent Validator

        #region Add MediaTr

        services.AddMediatR(handlers => handlers.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        #endregion Add MediaTr

        #region Behaviors

        services.Configure<ApiBehaviorOptions>(opts => opts.SuppressModelStateInvalidFilter = true);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        #endregion  Behaviors

        return services;
    }
}