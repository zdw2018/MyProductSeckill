using OrderMicroService.Context;
using OrderMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace OrderMicroService.Repositories
{
    public class OrderRespository : IOrderRespository
    {
        private readonly OrderDbcontext _orderDbcontext;
        public OrderRespository(OrderDbcontext orderDbcontext)
        {
            this._orderDbcontext = orderDbcontext;
        }
        public void Create(Order order)
        {
            _orderDbcontext.Set<Order>().Add(order);
            _orderDbcontext.SaveChanges();
        }

        public void Delete(Order order)
        {
            _orderDbcontext.Set<Order>().Remove(order);
            _orderDbcontext.SaveChanges();
        }

        public Order GetOrderById(int Id)
        {
            return _orderDbcontext.Set<Order>().Find(Id);
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orderDbcontext.Set<Order>().ToList();
        }

        public bool OrderExists(int Id)
        {
            return _orderDbcontext.Set<Order>().Any(x=>x.Id==Id);
            
        }

        public void Update(Order order)
        {
            _orderDbcontext.Set<Order>().Update(order);
            _orderDbcontext.SaveChanges();
        }
    }
}
