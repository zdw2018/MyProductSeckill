using SeckillAggregateService.Models.OrderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeckillAggregateService.Dtos.OrderService
{
    /// <summary>
    /// 预订单模型
    /// </summary>
    public class OrderDto
    {
        public int Id { get; set; }
        public string OrderType { get; set; }//订单类型
        public string OrderFlag { get; set; }//订单标志
        public int UserId { get; set; }//用户Id
        public string OrderSn { get; set; }//订单号
        public decimal OrderTotalPrice { get; set; }//订单总价
        public DateTime Createtime { get; set; }//创建时间
        public DateTime Updatetime { get; set; }//更新时间
        public DateTime Paytime { get; set; }//支付时间
        public DateTime Sendtime { get; set; }//发货时间
        public DateTime Successtime { get; set; }//订单完成时间
        public int OrderStatus { get; set; }//订单状态
        public string OrderName { get; set; }//订单名称
        public string OrderTel { get; set; }//订单电话
        public string OrderAddress { get; set; }//订单地址
        public string OrderRemark { get; set; }//订单备注
        //订单项Dto
        public List<OrderItem> OrderItems { get; set; }
    }
}
