using devboost.dronedelivery.core.domain.Constants;
using devboost.dronedelivery.sb.domain.Enums;
using System;

namespace devboost.dronedelivery.sb.domain.Extensions
{
    public static class TopicTypeExtensions
    {
        public static TopicType GetTopicType(string topic)
        {
            if (topic.Equals(CoreConstants.PedidoTopic))
            {
                return TopicType.PEDIDO;
            }
            else if (topic.Equals(CoreConstants.PagamentoTopic))
            {
                return TopicType.PAGAMENTO;
            }
            else
            {
                return TopicType.UNDEFINED;
            }

        }
    }
}