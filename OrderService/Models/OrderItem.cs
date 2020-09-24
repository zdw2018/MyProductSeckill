using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMicroService.Models
{
    /// <summary>
    /// 订单项模型
    /// </summary>
    public class OrderItem
    {
        [Key]
        public int Id  { get; set; }
        public int OrderSn { get; set; }//订单编号
        public string ProductId { get; set; }//订单号
        public int ProductUrl { get; set; }//商品主图
        public int ProductName { get; set; }//商品名称
        public decimal ItemPrice { get; set; }//订单项单价
        public int ItemCount { get; set; }//订单项数量
        public decimal ItemTotalPrice { get; set; }//订单项总价
    }
}
