using OrderMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMicroService.Repositories
{
    public interface IOrderItemRespository
    {
        void Create(OrderItem orderItem);
        void Delete(OrderItem orderItem);
        void Update(OrderItem orderItem);
        bool OrderItemExists(int Id);
        OrderItem GetOrderItemById(int Id);
        IEnumerable<OrderItem> GetOrderItemsByOrderSn(int OrderSn);

    }
}
