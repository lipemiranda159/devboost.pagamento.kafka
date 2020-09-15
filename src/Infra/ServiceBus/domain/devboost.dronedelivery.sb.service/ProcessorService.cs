using devboost.dronedelivery.sb.domain.Enums;
using devboost.dronedelivery.sb.domain.Extensions;
using devboost.dronedelivery.sb.domain.Interfaces;
using Hangfire;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace devboost.dronedelivery.sb.service
{
    public class ProcessorService : IProcessorQueue
    {
        private readonly IConsumer _consumer;
        private readonly ILoginProvider _loginProvider;
        private readonly IServiceFactory _serviceFactory;
        public ProcessorService(IConsumer consumer, ILoginProvider loginProvider, IServiceFactory serviceFactory)
        {
            _consumer = consumer;
            _loginProvider = loginProvider;
            _serviceFactory = serviceFactory;

        }

        [JobDisplayName("TopicName: {0}")]
        public async Task ProcessorQueueAsync(string topicName)
        {
            using var cancellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            var messages = await _consumer.ExecuteAsync(cancellationToken.Token, topicName);
            var processor = _serviceFactory.GetProcessor(TopicTypeExtensions.GetTopicType(topicName));
            var token = await _loginProvider.GetTokenAsync();
            foreach (var message in messages)
            {
                await processor.ProcessTopicAsync(token, message);
            }
        }
    }
}
