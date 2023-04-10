using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ecomm.Models;
using System.Threading.Tasks;
using Ecomm.DataAccess.OrderDetails;

namespace Ecomm.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderDetailsDb _orderDetailsProvider;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IOrderDetailsDb orderDetailsProvider, ILogger<HomeController> logger)
        {
            _orderDetailsProvider = orderDetailsProvider;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            OrderDetail[] orderDetails = await _orderDetailsProvider.Get();
            return View(orderDetails);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
