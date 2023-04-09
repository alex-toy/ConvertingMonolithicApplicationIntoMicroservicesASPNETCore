using System.Threading.Tasks;

namespace OrderService.Orders
{
    public interface IOrderCreator
    {
        Task<int> Create(OrderDetail orderDetail);
    }
}