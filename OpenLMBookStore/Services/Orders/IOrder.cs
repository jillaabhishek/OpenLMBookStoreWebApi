using Microsoft.AspNetCore.Mvc;
using OpenLMBookStore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenLMBookStore.Services.Orders
{
    public interface IOrder
    {
        Task<ActionResult<OrderModel>> OrderBook(OrderModel orderDto);

        Task<IEnumerable<OrderModel>> OrderBooks(IEnumerable<OrderModel> orderDtos);

        Task<ActionResult<OrderModel>> CancelOrder(string orderId);

        Task<ActionResult<OrderModel>> UpdateOrder(string orderId, OrderModel orderDto);
    }
}
