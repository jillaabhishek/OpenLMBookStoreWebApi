using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenLMBookStore.Dtos;
using OpenLMBookStore.Entities;
using OpenLMBookStore.Services.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenLMBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _order;

        public OrderController(IOrder order)
        {
            _order = order;
        }

        [HttpPost("OrderBook")]
        public async Task<ActionResult<OrderModel>> OrderBook(OrderModel orderDto)
        {
            return await _order.OrderBook(orderDto);
        }

        [HttpPost("OrderBooks")]
        public async Task<IEnumerable<OrderModel>> OrderBooks(IEnumerable<OrderModel> ordersDto)
        {
            return await _order.OrderBooks(ordersDto);
        }

        [HttpPut("{orderId}")]
        public async Task<ActionResult<OrderModel>> UpdateOrder(string orderId, OrderModel orderDto)
        {
            if (orderDto == null)
                return BadRequest("Order model is null");

            if (orderDto.OrderId != orderId)
                return BadRequest("Parameter BookId and model bookId doesn't match.");

            return await _order.UpdateOrder(orderId, orderDto);
        }

        [HttpDelete]
        public async Task<ActionResult> CancelOrder(string orderId)
        {
            if (string.IsNullOrEmpty(orderId))
                return NotFound("OrderId is null");

            await _order.CancelOrder(orderId);

            return Ok($"Order {orderId} deleted successfully");
        }
    }
}
