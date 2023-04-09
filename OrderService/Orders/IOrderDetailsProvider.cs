namespace OrderService.Orders
{
    public interface IOrderDetailsProvider
    {
        OrderDetail[] Get();
    }
}