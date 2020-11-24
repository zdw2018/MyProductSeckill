using OrderMicroService.Models;
using OrderMicroService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace OrderMicroService.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRespository _orderItemRespository;
        public OrderItemService(IOrderItemRespository orderItemRespository)
        {
            this._orderItemRespository = orderItemRespository;
        }
        public void Create(OrderItem orderItem)
        {
            _orderItemRespository.Create(orderItem);
        }

        public void Delete(OrderItem orderItem)
        {
            _orderItemRespository.Delete(orderItem);
        }

        public OrderItem GetOrderItemById(int Id)
        {
            return _orderItemRespository.GetOrderItemById(Id);
        }

        public IEnumerable<OrderItem> GetOrderItems()
        {
            return _orderItemRespository.GetOrderItems();
        }

        public IEnumerable<OrderItem> GetOrderItemsByOrderSn(int OrderSn)
        {
            return _orderItemRespository.GetOrderItemsByOrderSn(OrderSn);
        }

        public bool OrderItemExists(int Id)
        {
            return _orderItemRespository.OrderItemExists(Id);
        }

        public void Update(OrderItem orderItem)
        {
            _orderItemRespository.Update(orderItem);
        }
    }
}
