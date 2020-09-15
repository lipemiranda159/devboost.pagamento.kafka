using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace devboost.dronedelivery.sb.domain.Interfaces
{
    public interface IProducer
    {
        Task<DeliveryResult<Null, string>> SendData(string topic, string message);
    }
}
