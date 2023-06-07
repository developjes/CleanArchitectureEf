using Example.Ecommerce.Application.Validator.Behaviors;
using Example.Ecommerce.Application.Validator.BusinessValidations.Feature.Ecommerce.Products.Create;
using Example.Ecommerce.Application.Validator.BusinessValidations.Feature.Ecommerce.Products.Delete;
using Example.Ecommerce.Application.Validator.BusinessValidations.Feature.Ecommerce.Products.Update;
using Example.Ecommerce.Application.Validator.FluentValidations.Ecommerce.Products.Commands.Create;
using Example.Ecommerce.Application.Validator.FluentValidations.Ecommerce.Products.Commands.Update;
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
        services.AddValidatorsFromAssemblyContaining<UpdateProductCommandValidator>();

        #endregion Fluent Validator

        #region Add MediaTr

        services.AddMediatR(handlers => handlers.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        #endregion Add MediaTr

        #region Behaviors

        services.Configure<ApiBehaviorOptions>(opts => opts.SuppressModelStateInvalidFilter = true);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        #endregion Behaviors

        #region Business validations

        services.AddScoped<BusinessValidationCreateProduct>();
        services.AddScoped<BusinessValidationUpdateProduct>();
        services.AddScoped<BusinessValidationDeleteProduct>();

        #endregion Business validation

        return services;
    }
}