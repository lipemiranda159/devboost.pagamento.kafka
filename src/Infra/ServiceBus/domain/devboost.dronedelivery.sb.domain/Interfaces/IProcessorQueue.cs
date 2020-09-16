using devboost.dronedelivery.sb.domain.DTO;
using System.Threading.Tasks;

namespace devboost.dronedelivery.sb.domain.Interfaces
{
    public interface IProcessorQueue
    {
        Task<HangfireResult> ProcessorQueueAsync(string topicName);
    }
}
