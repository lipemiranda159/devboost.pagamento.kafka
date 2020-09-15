using devboost.dronedelivery.sb.domain.Enums;
using devboost.dronedelivery.sb.domain.Interfaces;
using devboost.dronedelivery.sb.service;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace devboost.dronedelivery.sb.application
{
    public class ServiceFactory : IServiceFactory
    {
        private readonly IConfiguration _configuration;
        public ServiceFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public ITopicProcessorService GetProcessor(TopicType topicType)
        {
            switch (topicType)
            {
                case TopicType.PEDIDO:
                    return new PedidoTopicProcessor(_configuration);
                case TopicType.PAGAMENTO:
                    return null;
                default:
                    break;
            }

            return null;
        }
    }
}
