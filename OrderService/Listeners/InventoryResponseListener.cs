using Ecomm.Models;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using OrderService.Orders;
using Plain.RabbitMQ;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Listeners
{
    public class InventoryResponseListener : IHostedService
    {
        private readonly ISubscriber _subscriber;
        private readonly IOrderDb _orderDb;

        public InventoryResponseListener(ISubscriber subscriber, IOrderDb orderDb)
        {
            _subscriber = subscriber;
            _orderDb = orderDb;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _subscriber.Subscribe(HandleInventoryResponse);
            return Task.CompletedTask;
        }

        private bool HandleInventoryResponse(string message, IDictionary<string, object> header)
        {
            var response = JsonConvert.DeserializeObject<InventoryResponse>(message);
            if (!response.IsSuccess)
            {
                _orderDb.Delete(response.OrderId).GetAwaiter().GetResult();
            }
            return true;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
