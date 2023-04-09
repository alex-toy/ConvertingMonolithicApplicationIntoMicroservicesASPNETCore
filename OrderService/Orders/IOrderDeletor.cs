using System.Threading.Tasks;

namespace OrderService.Orders
{
    public interface IOrderDeletor
    {
        Task Delete(int orderId);
    }
}