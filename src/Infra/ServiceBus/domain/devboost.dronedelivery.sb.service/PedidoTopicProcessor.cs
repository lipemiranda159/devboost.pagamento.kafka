using devboost.dronedelivery.sb.domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace devboost.dronedelivery.sb.service
{
    public class PedidoTopicProcessor : HttpServiceBase, ITopicProcessorService
    {
        private const string PedidoUri = "api/Pedidos";

        public PedidoTopicProcessor(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task ProcessTopicAsync(string token, string topicValue)
        {
            await SendDataAsync(PedidoUri, topicValue, token);
        }
    }
}
