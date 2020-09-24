using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroService.Models
{
    /// <summary>
    /// 商品模型
    /// </summary>
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductCode { get; set; }//商品编码
        public string ProductUrl { get; set; }//商品主图
        public string ProductTitle { get; set; }//商品标题
        public string ProductDescription { get; set; }//图文描述
        public decimal ProductVirtualproce { get; set; }//商品虚拟价格
        public decimal ProductPrice { get; set; }//价格
        public int ProductSort { get; set; }//商品序号
        public int ProductSold { get; set; }//已售件数
        public int ProductStock { get; set; }//商品库存
        public string ProductStatus { get; set; }//商品状态
    }
}
