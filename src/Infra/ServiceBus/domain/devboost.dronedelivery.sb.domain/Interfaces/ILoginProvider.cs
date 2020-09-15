using System.Threading.Tasks;

namespace devboost.dronedelivery.sb.domain.Interfaces
{
    public interface ILoginProvider
    {
        Task<string> GetTokenAsync();
    }
}
