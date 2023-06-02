using Example.Ecommerce.Application.Validator.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Example.Ecommerce.Service.WebApi.Filters;

public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{
    /// <inheritdoc />
    public override void OnException(ExceptionContext context)
    {
        switch (context.Exception)
        {
            case ValidationException validationEx:
                HandleValidationException(context, validationEx);
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


    private static void HandleValidationException(ExceptionContext context, ValidationException exception)
    {
        ValidationProblemDetails details = new(exception.Errors)
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
        };

        context.Result = new BadRequestObjectResult(details);
        context.ExceptionHandled = true;
    }

    private static void HandleInvalidModelStateException(ExceptionContext context)
    {
        ValidationProblemDetails details = new(context.ModelState)
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
        };

        context.Result = new BadRequestObjectResult(details);
        context.ExceptionHandled = true;
    }

    private static void HandleNotFoundException(ExceptionContext context, NotFoundException exception)
    {
        ProblemDetails details = new()
        {
            Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            Title = "The specified resource was not found.",
            Detail = exception.Message
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
            Status = StatusCodes.Status500InternalServerError,
            Title = "An error occurred while processing your request.",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
        };

        context.Result = new ObjectResult(details)
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };

        context.ExceptionHandled = true;
    }
}