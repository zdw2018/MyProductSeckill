using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderMicroService.Services;
using OrderMicroService.Models;
using Microsoft.EntityFrameworkCore;

namespace OrderMicroService.Controllers
{
    /// <summary>
    /// 订单服务控制器
    /// </summary>
    [Route("Orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;
        private readonly IOrderService _orderService;
        public OrderController(IOrderService OrderService, IOrderItemService OrderItemService)
        {
            this._orderItemService = OrderItemService;
            this._orderService = OrderService;
        }
        /// <summary>
        /// 获取所有订单
        /// </summary>
        /// <returns></returns>
        // GET: api/Orders
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            return _orderService.GetOrders().ToList();
        }
        /// <summary>
        ///  查询订单（ID）
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Orders/5
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderById(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order != null)
            {
                return NotFound();
            }
            return order;
        }
        /// <summary>
        /// 通过订单ID判断订单是否存在
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        private bool OrderExists(int Id)
        {
            return _orderService.OrderExists(Id);
        }
        /// <summary>
        /// 更新订单信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public ActionResult PutOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            try
            {
                _orderService.Update(order);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<Order> PostOrder(Order order)
        {
            //1.创建订单
            order.Createtime = DateTime.Now;
            _orderService.Create(order);
            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [NonAction]
        public ActionResult<Order> CapPostOrder(Order order)
        {
            //1.创建订单
            order.Createtime = DateTime.Now;
            _orderService.Create(order);
            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }
        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public ActionResult<Order> DeleteOrder(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            _orderService.Delete(order);
            return order;
        }

    }
}
