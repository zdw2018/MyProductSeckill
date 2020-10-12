using OrderMicroService.Models;
using OrderMicroService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMicroService.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRespository _orderRespository;
        public OrderService(IOrderRespository orderRespository)
        {
            this._orderRespository = orderRespository;
        }
        public void Create(Order order)
        {
            _orderRespository.Create(order);
        }

        public void Delete(Order order)
        {
            _orderRespository.Delete(order);
        }

        public Order GetOrderById(int Id)
        {
            return _orderRespository.GetOrderById(Id);
        }
        public IEnumerable<Order> GetOrders()
        {
            return _orderRespository.GetOrders();
        }
        public bool OrderExists(int Id)
        {
            return _orderRespository.OrderExists(Id);
        }

        public void Update(Order order)
        {
            _orderRespository.Update(order);
        }
    }
}
