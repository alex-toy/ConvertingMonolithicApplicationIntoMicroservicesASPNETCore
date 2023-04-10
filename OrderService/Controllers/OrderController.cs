using System.Collections.Generic;
using System.Threading.Tasks;
using Ecomm.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderService.Models;
using OrderService.Orders;
using Plain.RabbitMQ;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderDetailsDb _orderDetailsProvider;
        private readonly IPublisher _publisher;
        private readonly IOrderDb _orderCreator;

        public OrderController(IOrderDetailsDb orderDetailsProvider, IPublisher publisher, IOrderDb orderCreator)
        {
            _orderDetailsProvider = orderDetailsProvider;
            _publisher = publisher;
            _orderCreator = orderCreator;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<OrderDetail> Get()
        {
            return _orderDetailsProvider.Get();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task Post([FromBody] OrderDetail orderDetail)
        {
            string message = JsonConvert.SerializeObject(orderDetail);
            string routingKey = "report.order";
            _publisher.Publish(message, routingKey, null);

            var id = await _orderCreator.Create(orderDetail);
            OrderRequest order = new OrderRequest
            {
                OrderId = id,
                ProductId = orderDetail.ProductId,
                Quantity = orderDetail.Quantity,
                ProductName = orderDetail.ProductName
            };
            message = JsonConvert.SerializeObject(order);
            routingKey = "order.created";
            _publisher.Publish(message, routingKey, null);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] OrderDetail orderDetail)
        {
            OrderRequest order = new OrderRequest
            {
                OrderId = id,
                ProductId = orderDetail.ProductId,
                Quantity = orderDetail.Quantity,
                ProductName = orderDetail.ProductName
            };
            string message = JsonConvert.SerializeObject(order);
            const string routingKey = "order.updated";
            _publisher.Publish(message, routingKey, null);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
