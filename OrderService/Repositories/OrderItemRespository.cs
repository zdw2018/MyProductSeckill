using OrderMicroService.Context;
using OrderMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace OrderMicroService.Repositories
{
    public class OrderItemRespository : IOrderItemRespository
    {
        private readonly OrderDbcontext _orderDbcontext;
        public OrderItemRespository(OrderDbcontext orderDbcontext)
        {
            this._orderDbcontext = orderDbcontext;
        }

        public void Create(OrderItem orderItem)
        {
            _orderDbcontext.Set<OrderItem>().Add(orderItem);
            _orderDbcontext.SaveChanges();
        }

        public void Delete(OrderItem orderItem)
        {
            _orderDbcontext.Set<OrderItem>().Remove(orderItem);
            _orderDbcontext.SaveChanges();
        }

        public OrderItem GetOrderItemById(int Id)
        {
            return _orderDbcontext.Set<OrderItem>().First(X => X.Id == Id);
        }

        public IEnumerable<OrderItem> GetOrderItemsByOrderSn(int OrderSn)
        {
            return _orderDbcontext.Set<OrderItem>().Where(x => x.OrderSn == OrderSn);
        }

        public bool OrderItemExists(int Id)
        {
            return _orderDbcontext.Set<OrderItem>().Any(X=>X.Id==Id);
        }

        public void Update(OrderItem orderItem)
        {
            _orderDbcontext.Set<OrderItem>().Update(orderItem);
            _orderDbcontext.SaveChanges();
        }
    }
}
