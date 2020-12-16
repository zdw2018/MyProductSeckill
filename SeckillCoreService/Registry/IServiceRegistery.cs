using System;
using System.Collections.Generic;
using System.Text;

namespace SeckillCoreService.Registry
{
    /// <summary>
    /// 服务注册
    /// </summary>
    public interface IServiceRegistery
    {
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="serviceNode"></param>
        void Register(ServiceRegistryConfig serviceNode);
        /// <summary>
        /// 服务撤销
        /// </summary>
        /// <param name="serviceNode"></param>
        void DeRegister(ServiceRegistryConfig serviceNode);
    }
}
