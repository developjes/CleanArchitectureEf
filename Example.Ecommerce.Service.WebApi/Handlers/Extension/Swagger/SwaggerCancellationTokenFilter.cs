using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Microsoft.Win32.SafeHandles;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Example.Ecommerce.Service.WebApi.Handlers.Extension.Swagger
{
    public class SwaggerCancellationTokenFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            ApiDescription apiDescription = context.ApiDescription;
            IEnumerable<OpenApiParameter?> excludedParameters = apiDescription.ParameterDescriptions

                .Where(p =>
                    new Type?[]
                    {
                        typeof(CancellationToken) , typeof(CancellationToken) , typeof(CancellationToken)
                    }.Contains(p.ModelMetadata.ContainerType))
                .Select(p => operation.Parameters.FirstOrDefault(operationParam => operationParam.Name == p.Name));

            foreach (var parameter in excludedParameters)
                operation.Parameters.Remove(parameter);
        }
    }
}