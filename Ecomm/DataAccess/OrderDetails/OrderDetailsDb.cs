using Ecomm.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ecomm.DataAccess.OrderDetails
{
    public class OrderDetailsDb : IOrderDetailsDb
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<OrderDetailsDb> logger;

        public OrderDetailsDb(IHttpClientFactory httpClientFactory, ILogger<OrderDetailsDb> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }

        public async Task<OrderDetail[]> Get()
        {
            try
            {
                using var client = httpClientFactory.CreateClient("order");
                var response = await client.GetAsync("/api/order");
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<OrderDetail[]>(data);
            }
            catch (Exception exc)
            {
                logger.LogError($"Error getting order details {exc}");
                return Array.Empty<OrderDetail>();
            }
        }
    }
}