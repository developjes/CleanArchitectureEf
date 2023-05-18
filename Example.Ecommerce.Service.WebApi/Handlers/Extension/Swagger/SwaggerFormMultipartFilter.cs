using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Example.Ecommerce.Service.WebApi.Handlers.Extension.Swagger
{
    public class SwaggerFormMultipartFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (context.ApiDescription.HttpMethod != "POST" && context.ApiDescription.HttpMethod != "PUT") return;

            if (Array.Find(context.MethodInfo.GetCustomAttributes(true), a => a.GetType() == typeof(ConsumesAttribute)) is not ConsumesAttribute consumesAttribute
                || !consumesAttribute.ContentTypes.Any(
                    ct => ct.Equals("multipart/form-data", StringComparison.InvariantCultureIgnoreCase)))
            {
                return;
            }

            ParameterInfo? paramInfo = Array.Find(context.MethodInfo.GetParameters(), p => p.GetCustomAttribute<FromFormAttribute>() is not null);
            if (paramInfo is null) return;

            //Now we're going to rewrite the operation to fix it.
            OpenApiSchema referenceSchema;
            if (!context.SchemaRepository.Schemas.ContainsKey(paramInfo.ParameterType.Name))
                referenceSchema = context.SchemaGenerator.GenerateSchema(paramInfo.ParameterType, context.SchemaRepository);
            else
                referenceSchema = context.SchemaRepository.Schemas.First(s => s.Key == paramInfo.ParameterType.Name).Value;

            OpenApiMediaType mediaType = operation.RequestBody.Content.First().Value;
            mediaType.Schema = new OpenApiSchema { Reference = referenceSchema.Reference };

            mediaType.Encoding.Clear();
        }
    }
}
