using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroService.Pos
{
    /// <summary>
    /// 商品值对象，主要接收客户端传过来的参数
    /// </summary>
    public class ProductPo
    {
        //商品编号
        public int ProductId { get; set; }
        //商品数量
        public int ProductCount { get; set; }
    }
}
