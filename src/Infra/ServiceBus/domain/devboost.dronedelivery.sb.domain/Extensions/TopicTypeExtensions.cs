using devboost.dronedelivery.sb.domain.Constants;
using devboost.dronedelivery.sb.domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace devboost.dronedelivery.sb.domain.Extensions
{
    public static class TopicTypeExtensions
    {
        public static TopicType GetTopicType(string topic)
        {
            if (topic.Equals(ProjectConsts.PedidoTopic))
            {
                return TopicType.PEDIDO;
            }
            else if (topic.Equals(ProjectConsts.PagamentoTopic))
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