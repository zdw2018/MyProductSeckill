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
            throw new NotImplementedException();
        }

        public OrderItem GetOrderItemById(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderItem> GetOrderItemsByOrderSn(int OrderSn)
        {
            throw new NotImplementedException();
        }

        public bool OrderItemExists(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }
    }
}
