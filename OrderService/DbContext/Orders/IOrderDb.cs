using OrderService.Models;
using System.Threading.Tasks;

namespace OrderService.Orders
{
    public interface IOrderDb
    {
        Task<int> Create(OrderDetail orderDetail);
        Task Delete(int orderId);
    }
}