using devboost.dronedelivery.core.domain;
using devboost.dronedelivery.core.services;
using devboost.dronedelivery.domain.Constants;
using devboost.dronedelivery.pagamento.EF.Integration.Interfaces;
using devboost.dronedelivery.sb.domain.Interfaces;
using devboost.dronedelivery.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.dronedelivery.pagamento.EF.Integration
{
    public class PagamentoIntegration : IPagamentoIntegration
    {
        private readonly string _urlBase;
        private readonly IProducer _producer;
        public PagamentoIntegration(DeliverySettingsData deliverySettings, IProducer producer)
        {
            _urlBase = deliverySettings.UrlBase;
            _producer = producer;
        }

        public async Task<bool> ReportarResultadoAnalise(List<PagamentoStatusDto> listaPagamentos)
        {
            await _producer.SendData("", JsonConvert.SerializeObject(listaPagamentos));
            return true;
        }
    }
}
