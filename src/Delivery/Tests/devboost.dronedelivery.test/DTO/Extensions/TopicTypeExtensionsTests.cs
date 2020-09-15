using devboost.dronedelivery.core.domain.Constants;
using devboost.dronedelivery.sb.domain.Extensions;
using Xunit;

namespace devboost.dronedelivery.test.DTO.Extensions
{
    public class TopicTypeExtensionsTests
    {
        [Fact]
        public void GetTopicTypeTests()
        {
            var topicTypePedido = TopicTypeExtensions.GetTopicType(CoreConstants.PedidoTopic);
            Assert.True(topicTypePedido == sb.domain.Enums.TopicType.PEDIDO);
            var topicTypePagamento = TopicTypeExtensions.GetTopicType(CoreConstants.PagamentoTopic);
            Assert.True(topicTypePagamento == sb.domain.Enums.TopicType.PAGAMENTO);

        }
    }
}
