using Ecomm.Models;
using System.Threading.Tasks;

namespace Ecomm.DataAccess.Inventories
{
    public interface IInventoryDb
    {
        Inventory[] Get();
        Task Update(OrderRequest orderRequest);
    }
}