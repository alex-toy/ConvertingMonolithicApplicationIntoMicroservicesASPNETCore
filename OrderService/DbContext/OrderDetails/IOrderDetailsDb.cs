using OrderService.Models;

namespace OrderService.Orders
{
    public interface IOrderDetailsDb
    {
        OrderDetail[] Get();
    }
}