using System.Threading.Tasks;

namespace devboost.dronedelivery.sb.domain.Interfaces
{
    public interface IPedidosService
    {
        Task ProcessPedidoAsync(string token, string pedido);
    }
}
