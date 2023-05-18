using Example.Ecommerce.Application.Interface.Persistence.ExternalServices;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Web;

namespace Example.Ecommerce.Persistence.ExternalServices
{
    public class RestService : IRestService
    {
        private readonly HttpClient client;

        public RestService() => client = new HttpClient();

        private static void AddHeaders(HttpRequestMessage httpRequestMessage, Dictionary<string, string> headers)
        {
            if (headers?.Count.Equals(0) is not false) return;

            foreach (KeyValuePair<string, string> header in headers)
            {
                switch (header.Key)
                {
                    case "Authorization":
                        string[] authentication = header.Value.Split(' ');
                        httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue(authentication[0], authentication[1]);
                        break;
                    case "Accept":
                        httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(header.Value));
                        break;
                    default:
                        httpRequestMessage.Headers.Add(header.Key, header.Value);
                        break;
                }
            }
        }

        private static async Task AddContentBody(HttpRequestMessage httpRequestMessage, StringContent parameters, string contentType)
        {
            httpRequestMessage.Content = parameters;
        }

        private static string AddQueryString(string url, Dictionary<string, string> parameters = default!)
        {
            if (parameters is not null)
            {
                if (string.IsNullOrEmpty(url)) throw new ArgumentException($"{nameof(url)} cannot be null or empty");

                return string.Format(url + "{0}", HttpUtility.UrlEncode(
                    string.Join('&', parameters.Select(param => string.Format("{0}={1}", param.Key, param.Value)
                ))));
            }

            return url;
        }

        public async Task<T?> GetJson<T>(string url, Dictionary<string, string> parameters = default!,
            Dictionary<string, string> headers = default!)
        {
            if (string.IsNullOrEmpty(url)) throw new ArgumentException($"{nameof(url)} cannot be null or empty");


            url = AddQueryString(url, parameters);

            HttpRequestMessage httpRequestMessage = new() { Method = HttpMethod.Get, RequestUri = new Uri(url) };
            AddHeaders(httpRequestMessage, headers);

            HttpResponseMessage httpResponse = await client.SendAsync(httpRequestMessage);

            T? data = default;
            if (httpResponse.IsSuccessStatusCode)
            {
                string dataString = await httpResponse.Content.ReadAsStringAsync();
                data = await httpResponse.Content.ReadFromJsonAsync<T?>(new JsonSerializerOptions());
            }

            return data;
        }

        public async Task<Output> PostJson<Input, Output>(string url, string contentType, Input parameters,
            Dictionary<string, string> headers = default!)
        {
            if (string.IsNullOrEmpty(url)) throw new ArgumentException($"{nameof(url)} cannot be null or empty");

            HttpRequestMessage httpRequestMessage = new(HttpMethod.Post, url);

            AddHeaders(httpRequestMessage, headers);

            StringContent stringParameters = new StringContent(JsonSerializer.Serialize(parameters), Encoding.UTF8, contentType);
            string stringResult = await stringParameters.ReadAsStringAsync();
            await AddContentBody(httpRequestMessage, stringParameters, contentType);

            HttpResponseMessage httpResponse = await client.SendAsync(httpRequestMessage);

            Output? data = default;
            if (httpResponse.IsSuccessStatusCode)
            {
                string dataString = await httpResponse.Content.ReadAsStringAsync();
                data = await httpResponse.Content.ReadFromJsonAsync<Output?>();
            }

            return data;
        }
    }
}