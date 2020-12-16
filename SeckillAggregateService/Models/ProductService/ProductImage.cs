using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeckillAggregateService.Models.ProductService
{
    /// <summary>
    /// 商品图片
    /// </summary>
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }//编号
        public int ProductId { get; set; }//商品编号
        public int ImageSort { get; set; }//排序
        public string ImageStatus { get; set; }//状态（1：启用 2：禁用）
        public string ImageUrl { get; set; }//图片url
    }
}
