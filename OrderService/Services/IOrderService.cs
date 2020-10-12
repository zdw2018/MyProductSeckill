using OrderMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMicroService.Services
{
  public  interface IOrderService
    {
        void Create(Order order);
        void Delete(Order order);
        void Update(Order order);
        bool OrderExists(int Id);
        Order GetOrderById(int Id);
        IEnumerable<Order> GetOrders();
    }
}
