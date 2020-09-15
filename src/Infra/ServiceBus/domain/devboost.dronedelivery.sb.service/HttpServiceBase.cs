using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace devboost.dronedelivery.sb.service
{
    public class HttpServiceBase
    {
        protected readonly string _urlPedidos;
        private const string MediaType = "application/json";
        private const string AuthorizationType = "Bearer";

        public HttpServiceBase(IConfiguration configuration)
        {
            _urlPedidos = configuration.GetSection("UrlPedidos").Value;
        }

        public async Task SendDataAsync(string uri, string requestTopic, string token)
        {
            using var httpClient = new HttpClient
            {
                BaseAddress = new Uri(_urlPedidos)
            };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthorizationType, token);
            var request = new StringContent(requestTopic, Encoding.UTF8, MediaType);
            var response = await httpClient.PostAsync(uri, request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error to post pedido");
            }

        }

    }
}
