using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeckillAggregateService.Models.SeckillService
{
    /// <summary>
    /// 秒杀模型（秒杀商品）
    /// </summary>
    public class Seckill
    {
        [Key]
        public int Id { get; set; }
        public int SeckillType { get; set; }//秒杀类型
        public string SeckillName { get; set; }//秒杀名称
        public string SeckillUrl { get; set; }//秒杀Url
        public decimal SeckillPrice { get; set; }//秒杀价格
        public int SeckillStock { get; set; }//秒杀库存
        public string SeckillPercent { get; set; }//秒杀百分比
        public int TimeId { get; set; }//秒杀时间编号
        public int ProductId { get; set; }//商品编号
        public int SeckillLimit { get; set; }//秒杀数量限制
        public string SeckillDescription { get; set; }//秒杀描述
        public int SeckillIsEnd { get; set; }//秒杀是否结束
        public int SeckillStatus { get; set; }//秒杀状态

    }
}
