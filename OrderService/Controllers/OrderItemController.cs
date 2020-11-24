using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderMicroService.Models;
using OrderMicroService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderMicroService.Controllers
{
    /// <summary>
    /// 订单项服务控制器
    /// </summary>
    [Route("Order/{OrderId}/OrderItems")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private IOrderItemService _orderItemService;
        public OrderItemController(IOrderItemService orderItemService)
        {
            this._orderItemService = orderItemService;
        }

        // GET: api/<OrderItemController>
        [HttpGet]
        public ActionResult<IEnumerable<OrderItem>> GetOrderItems()
        {
            return _orderItemService.GetOrderItems().ToList();
        }

        // GET api/<OrderItemController>/5
        [HttpGet("{id}")]
        public ActionResult<OrderItem> GetOrderItem(int id)
        {
            var orderItem = _orderItemService.GetOrderItemById(id);
            if (orderItem == null)
            {
                return NotFound();
            }
            return orderItem;
        }

        // POST api/<OrderItemController>
        [HttpPost]
        public ActionResult<OrderItem> PostOrderItem(OrderItem orderItem)
        {
            _orderItemService.Create(orderItem);
            return CreatedAtAction("GetOrderItem", new { id = orderItem.Id }, orderItem);
        }

        // PUT api/<OrderItemController>/5
        [HttpPut("{id}")]
        public IActionResult PutOrderItem(int id, OrderItem orderItem)
        {
            if (id != orderItem.Id)
            {
                return BadRequest();
            }
            try
            {
                _orderItemService.Update(orderItem);
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!OrderItemExists(id))
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

        // DELETE api/<OrderItemController>/5
        [HttpDelete("{id}")]
        public ActionResult<OrderItem> DeleteOrderItem(int id)
        {
            var orderitem = _orderItemService.GetOrderItemById(id);
            if (orderitem == null)
            {
                return NotFound();
            }
            _orderItemService.Delete(orderitem);
            return orderitem;
        }
        private bool OrderItemExists(int id)
        {
            return _orderItemService.OrderItemExists(id);
        }
    }
}
