using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeckillAggregateService.Dtos.PaymentService
{
    /// <summary>
    /// 支付Dto
    /// </summary>
    public class PaymentDto
    {
        public int OrderId { get; set; }//订单主键
        public string OrderSn { get; set; }//订单号
        public decimal OrderTotalPrice { get; set; }//订单金额
        public int UserId { get; set; }//用户编号
        public int ProductId { get; set; }//商品编号
        public string ProductName { get; set; }//商品名称
    }
}
