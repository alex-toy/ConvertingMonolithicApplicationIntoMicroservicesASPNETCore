using Ecomm.Models;
using System.Threading.Tasks;

namespace Ecomm.DataAccess.OrderDetails
{
    public interface IOrderDetailsDb
    {
        Task<OrderDetail[]> Get();
    }
}