using Ecomm.Models;

namespace Ecomm.DataAccess.Products
{
    public interface IProductProvider
    {
        Product[] Get();
    }
}