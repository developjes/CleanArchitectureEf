using System.Text.Json.Serialization;

namespace Example.Ecommerce.Service.WebApi.Errors;

public class CodeErrorResponse
{
    [JsonPropertyName("statusCode")]
    public int StatusCode { get; set; }

    [JsonPropertyName("message")]
    public string[]? Message { get; set; }

    public CodeErrorResponse(int statusCode, string[]? message = null)
    {
        StatusCode = statusCode;
        if(message is null)
        {
            Message = Array.Empty<string>();
            Message[0] = GetDefaultMessageStatusCode(statusCode);

            return;
        }

        Message = message;
    }

    private static string GetDefaultMessageStatusCode(int statusCode)
    {
        return statusCode switch
        {
            400 => "El Request enviado tiene errores",
            401 => "No tienes authorization para este recurso",
            404 => "No se encontro el recurso solicitado",
            500 => "Se produjeron errores en el servidor",
            _ => string.Empty
        };
    }
}