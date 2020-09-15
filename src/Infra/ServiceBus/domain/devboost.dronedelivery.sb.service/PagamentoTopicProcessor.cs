using devboost.dronedelivery.sb.domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace devboost.dronedelivery.sb.service
{
    public class PagamentoTopicProcessor : HttpServiceBase, ITopicProcessorService
    {
        private const string PagamentoUri = "/api/pagamento";

        public PagamentoTopicProcessor(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task ProcessTopicAsync(string token, string topicValue)
        {
            await SendDataAsync(PagamentoUri, topicValue, token);

        }
    }
}
