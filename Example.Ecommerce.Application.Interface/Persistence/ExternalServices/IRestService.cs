namespace Example.Ecommerce.Application.Interface.Persistence.ExternalServices
{
    public interface IRestService
    {
        Task<T> GetJson<T>(string url, Dictionary<string, string> parameters = default!,
            Dictionary<string, string> headers = default!);
        Task<Output> PostJson<Input, Output>(string url, string contentType, Input parameters,
            Dictionary<string, string> headers = default!);
    }
}
