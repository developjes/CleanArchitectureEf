using System.Net;
using System.Text.Json;

namespace Example.Ecommerce.Service.WebApi.Handlers.Middleware
{
    public class TaskCanceledMiddleware
    {
        private readonly RequestDelegate _next;

        public TaskCanceledMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                HttpResponse response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case TaskCanceledException:
                        // custom application error
                        // Non-Standard status code - Client Closed Request
                        response.StatusCode = 499;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                string result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
