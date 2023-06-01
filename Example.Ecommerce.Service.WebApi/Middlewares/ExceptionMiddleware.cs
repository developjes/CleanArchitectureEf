using Example.Ecommerce.Application.Validator.Exceptions;
using Example.Ecommerce.Service.WebApi.Exceptions;
using System.Net;
using System.Text.Json;

namespace Example.Ecommerce.Service.WebApi.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger) =>
        (_next, _logger) = (next, logger);

    public async Task InvokeAsync(HttpContext context)
    {
        try { await _next(context); }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            context.Response.ContentType = "application/json";

            int statusCode;
            string result = string.Empty;
            JsonSerializerOptions jsonSerializerOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            switch (ex)
            {
                case NotFoundException:
                    statusCode = (int)HttpStatusCode.NotFound;
                    break;

                case FluentValidation.ValidationException validationException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    string[] errors = validationException.Errors.Select(ers => ers.ErrorMessage).ToArray();
                    string validationJsons = JsonSerializer.Serialize(errors, jsonSerializerOptions);

                    result = JsonSerializer
                        .Serialize(new CodeErrorException(statusCode, errors, validationJsons), jsonSerializerOptions);
                    break;

                case BadRequestException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    break;

                default:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            if (string.IsNullOrWhiteSpace(result))
            {
                result = JsonSerializer.Serialize(
                    new CodeErrorException(statusCode, new string[] { ex.Message }, ex.StackTrace),
                    jsonSerializerOptions
                );
            }

            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(result);
        }
    }
}