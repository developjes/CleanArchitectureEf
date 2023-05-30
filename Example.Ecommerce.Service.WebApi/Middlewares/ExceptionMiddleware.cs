using System.Net;
using Example.Ecommerce.Application.Validator.Exceptions;
using Example.Ecommerce.Service.WebApi.Exceptions;
using Newtonsoft.Json;

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

            switch (ex)
            {
                case NotFoundException:
                    statusCode = (int)HttpStatusCode.NotFound;
                    break;

                case FluentValidation.ValidationException validationException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    string[] errors = validationException.Errors.Select(ers => ers.ErrorMessage).ToArray();
                    string validationJsons = JsonConvert.SerializeObject(errors);

                    result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, errors, validationJsons));
                    break;

                case BadRequestException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    break;

                default:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            if (string.IsNullOrEmpty(result))
                result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, new string[] { ex.Message }, ex.StackTrace));

            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(result);
        }
    }
}