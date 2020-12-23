using System;
using System.Collections.Generic;
using System.Text;

namespace MyProductSeckill.Core.Registry.Options
{
    /// <summary>
    /// 服务发现选项
    /// </summary>
    public class ServiceDiscoveryOptions
    {
        public ServiceDiscoveryOptions()
        {
            //默认地址
            this.DiscoveryAddress = "https://localhost:8500";
        }
        /// <summary>
        /// 服务发现地址
        /// </summary>
        public string DiscoveryAddress { get; set; }
    }
}
