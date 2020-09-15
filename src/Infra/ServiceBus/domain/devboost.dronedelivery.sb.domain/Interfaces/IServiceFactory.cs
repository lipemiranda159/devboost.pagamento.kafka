using devboost.dronedelivery.sb.domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace devboost.dronedelivery.sb.domain.Interfaces
{
    public interface IServiceFactory
    {
        ITopicProcessorService GetProcessor(TopicType topicType);
    }
}
