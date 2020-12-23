using System;
using System.Collections.Generic;
using System.Text;

namespace MyProductSeckill.Core.Registry
{
    /// <summary>
    /// 服务发现
    /// </summary>
    public interface IServiceDiscovery
    {
        /// <summary>
        /// 服务发现
        /// </summary>
        /// <param name="ServiceName">服务名称</param>
        /// <returns></returns>
        List<ServiceNode> Discovery(string ServiceName);
    }
}
