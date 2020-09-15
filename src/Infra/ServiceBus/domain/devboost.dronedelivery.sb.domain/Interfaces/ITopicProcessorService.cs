using System.Threading.Tasks;

namespace devboost.dronedelivery.sb.domain.Interfaces
{
    public interface ITopicProcessorService
    {
        Task ProcessTopicAsync(string token, string topicValue);
    }
}
