using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenLMBookStore.Dtos;
using OpenLMBookStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenLMBookStore.Services.Orders
{
    public class OrderService : IOrder
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public OrderService(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ActionResult<OrderModel>> OrderBook(OrderModel orderDto)
        {
            if (orderDto != null)
            {
                if (string.IsNullOrEmpty(orderDto.OrderId))
                    orderDto.OrderId = Guid.NewGuid().ToString();

                if (string.IsNullOrEmpty(orderDto.Address.AddressId))
                    orderDto.Address.AddressId = Guid.NewGuid().ToString();

                Order order = _mapper.Map<Order>(orderDto);

                _dbContext.Attach(order.Book);               

                _dbContext.Orders.Add(order);

                await _dbContext.SaveChangesAsync();

                int pendingQuantity = order.Book.Quantity - orderDto.Quantity;
                order.Book.Quantity = pendingQuantity > 0 ? pendingQuantity : 0;

                _dbContext.Books.Update(order.Book);

                await _dbContext.SaveChangesAsync();

                return _mapper.Map<OrderModel>(order);
            }

            return null;
        }

        public async Task<IEnumerable<OrderModel>> OrderBooks(IEnumerable<OrderModel> orderDtos)
        {
            if (orderDtos != null && orderDtos.Count() > 0)
            {
                List<OrderModel> orderModel = new List<OrderModel>();

                foreach (OrderModel orderDto in orderDtos)
                {
                    var ordermodel = await OrderBook(orderDto);
                    orderModel.Add(ordermodel.Value);
                }

                return orderModel;
            }

            return null;
        }

        public async Task<ActionResult<OrderModel>> UpdateOrder(string orderId, OrderModel orderDto)
        {
            Order existingOrder = await _dbContext.Orders.FirstOrDefaultAsync(x => x.OrderId.Equals(orderId));

            if (existingOrder != null)
            {
                Order order = _mapper.Map<Order>(orderDto);

                _dbContext.Orders.Add(order);

                if (order.Address != null)
                    _dbContext.Addresses.Add(order.Address);

                await _dbContext.SaveChangesAsync();

                return _mapper.Map<OrderModel>(order);
            }

            return null;
        }

        public async Task<ActionResult<OrderModel>> CancelOrder(string orderId)
        {
            if (!string.IsNullOrEmpty(orderId))
            {

                Order order = await _dbContext.Orders
                                              .FirstOrDefaultAsync(x => x.OrderId.Equals(orderId));

                _dbContext.Orders.Remove(order);
                _dbContext.Addresses.Remove(order.Address);

                await _dbContext.SaveChangesAsync();

                return _mapper.Map<OrderModel>(order);
            }

            return null;
        }
    }
}
