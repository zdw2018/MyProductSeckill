using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeckillMicroService.Models
{
    /// <summary>
    /// 秒杀时间模型
    /// </summary>
    public class SeckillTimeModel
    {
        [Key]
        public int Id { get; set; }//秒杀时间编号
        public string TimeTitleUrl { get; set; }//秒杀时间主题url
        public string SeckillDate { get; set; }//秒杀日期（2020/8/10）
        public string SeckillStarttime { get; set; }//秒杀开始时间点(20:00)
        public string SeckillEndtime { get; set; }//秒杀结束时间点(22:00)
        public int TimeStatus { get; set; }//秒杀时间状态（0 启动 1禁用）
    }
}
