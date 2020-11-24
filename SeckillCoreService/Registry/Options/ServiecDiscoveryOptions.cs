using System;
using System.Collections.Generic;
using System.Text;

namespace SeckillCoreService.Registry.Options
{
    public class ServiecDiscoveryOptions
    {
        public ServiecDiscoveryOptions()
        {
            //默认地址
            this.DiscoveryAddress = "http://localhost:8500";
        }
        //服务发现地址
        public string DiscoveryAddress { get; set; }
    }
}
