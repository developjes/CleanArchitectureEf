using Example.Ecommerce.Application.Validator.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Example.Ecommerce.Service.WebApi.Models.Exceptions;

namespace Example.Ecommerce.Service.WebApi.Filters;

/// <summary>
/// Api filter for exceptions cases
/// </summary>
public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="context">Contexto input data</param>
    public override void OnException(ExceptionContext context)
    {
        switch (context.Exception)
        {
            case FluentValidationException fluentValidationEx:
                HandleFluentValidationException(context, fluentValidationEx);
                break;
            case MessageValidationException messageValidationEx:
                HandleMessageValidationException(context, messageValidationEx);
                break;
            case NotFoundException notFoundEx:
                HandleNotFoundException(context, notFoundEx);
                break;
            case ForbiddenAccessException:
                HandleForbiddenAccessException(context);
                break;
            default:
                HandleUnknownException(context);
                break;
        }

        base.OnException(context);
    }

    private static void HandleFluentValidationException(ExceptionContext context, FluentValidationException exception)
    {
        ValidationProblemDetails details = new(exception.Errors)
        {
            Status = StatusCodes.Status422UnprocessableEntity,
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
        };

        context.Result = new BadRequestObjectResult(details) { StatusCode = StatusCodes.Status422UnprocessableEntity };
        context.ExceptionHandled = true;
    }

    private static void HandleNotFoundException(ExceptionContext context, NotFoundException exception)
    {
        ProblemDetails details = new()
        {
            Detail = exception.Message,
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            Title = "The specified resource was not found."
        };

        context.Result = new NotFoundObjectResult(details);
        context.ExceptionHandled = true;
    }

    private static void HandleForbiddenAccessException(ExceptionContext context)
    {
        ProblemDetails details = new()
        {
            Status = StatusCodes.Status403Forbidden,
            Title = "Forbidden",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.3"
        };

        context.Result = new ObjectResult(details) { StatusCode = StatusCodes.Status403Forbidden };
        context.ExceptionHandled = true;
    }

    private static void HandleUnknownException(ExceptionContext context)
    {
        if (!context.ModelState.IsValid)
        {
            HandleInvalidModelStateException(context);
            return;
        }

        ProblemDetails details = new()
        {
            Detail = context.Exception.Message,
            Status = StatusCodes.Status500InternalServerError,
            Title = "An error occurred while processing your request.",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
        };

        context.Result = new ObjectResult(details) { StatusCode = StatusCodes.Status500InternalServerError };
        context.ExceptionHandled = true;
    }

    private static void HandleInvalidModelStateException(ExceptionContext context)
    {
        ValidationProblemDetails details = new(context.ModelState) { Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",  };

        context.Result = new BadRequestObjectResult(details);
        context.ExceptionHandled = true;
    }

    private static void HandleMessageValidationException(ExceptionContext context, MessageValidationException exception)
    {
        CodeError details = new()
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "One or more validation message have occurred.",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            Messages = exception.Messages
        };

        context.Result = new BadRequestObjectResult(details) { StatusCode = StatusCodes.Status400BadRequest };
        context.ExceptionHandled = true;
    }
}