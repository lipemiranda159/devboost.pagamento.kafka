using Confluent.Kafka;
using devboost.dronedelivery.sb.domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace devboost.dronedelivery.sb.service
{
    public class ProducerService : ServiceBase, IProducer
    {
        public ProducerService(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<DeliveryResult<Null, string>> SendData(string topic, string message)
        {
            string bootstrapServers = _kafcaConnection;
            var nomeTopic = topic;


            var config = new ProducerConfig
            {
                BootstrapServers = bootstrapServers
            };

            using var producer = new ProducerBuilder<Null, string>(config).Build();

            return await producer.ProduceAsync(
                nomeTopic,
                new Message<Null, string>
                { Value = message });
        }

    }
}

