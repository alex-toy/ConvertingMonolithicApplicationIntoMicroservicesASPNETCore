using Ecomm.DataAccess;
using Ecomm.DataAccess.Inventories;
using Ecomm.Models;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Plain.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ecomm
{
    public class OrderListener : IHostedService
    {
        private readonly IPublisher _publisher;
        private readonly ISubscriber _subscriber;
        private readonly IInventoryDb _inventoryDb;

        public OrderListener(IPublisher publisher, ISubscriber subscriber, IInventoryDb inventoryUpdator)
        {
            _publisher = publisher;
            _subscriber = subscriber;
            _inventoryDb = inventoryUpdator;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _subscriber.Subscribe(HandleOrderRequest);
            return Task.CompletedTask;
        }

        private bool HandleOrderRequest(string message, IDictionary<string, object> header)
        {
            OrderRequest orderRequest = JsonConvert.DeserializeObject<OrderRequest>(message);
            try
            {
                _inventoryDb.Update(orderRequest).GetAwaiter().GetResult();
                var inventoryResponse = new InventoryResponse { OrderId = orderRequest.OrderId, IsSuccess = true };
                string inventoryMessage = JsonConvert.SerializeObject(inventoryResponse);
                _publisher.Publish(inventoryMessage, "inventory.response", null);
            }
            catch (Exception)
            {
                InventoryResponse inventoryResponse = new InventoryResponse { OrderId = orderRequest.OrderId, IsSuccess = false };
                _publisher.Publish(JsonConvert.SerializeObject(inventoryResponse), "inventory.response", null);
            }

            return true;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }

    

    
}
