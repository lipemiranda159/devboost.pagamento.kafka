using System.Threading.Tasks;

namespace devboost.dronedelivery.sb.domain.Interfaces
{
    public interface IProcessorQueue
    {
        Task ProcessorQueueAsync(string topicName);
    }
}
