using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeckillAggregateService.Models.PaymentService
{
    /// <summary>
    /// 支付模型
    /// </summary>
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public int PaymentPrice { get; set; }//支付编号
        public int PaymentStatus { get; set; }//支付金额
        public int OrderId { get; set; }//支付状态
        public int PaymentType { get; set; }//支付类型
        public string PaymentMethod { get; set; }//支付方式
        public DateTime Createtime { get; set; }//支付创建时间
        public DateTime Updatetime { get; set; }//支付更新时间
        public string PaymentRemark { get; set; }//支付备注
        public string PaymentUrl { get; set; }//支付Url
        public string PaymentReturnUrl { get; set; }//支付回调url
        public string PaymentCode { get; set; }//支付单号
        public string UserId { get; set; }//用户ID
        public string PaymentErrorNo { get; set; }//支付错误编号
        public string PaymentErrorInfo { get; set; }   //支付错误信息
    }
}
