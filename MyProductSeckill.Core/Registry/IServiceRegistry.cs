using System;
using System.Collections.Generic;
using System.Text;

namespace MyProductSeckill.Core.Registry
{
    /// <summary>
    /// 服务注册
    /// </summary>
    public interface IServiceRegistry
    {
        /// <summary>
        /// 服务注册
        /// </summary>
        void Register();
        /// <summary>
        /// 服务撤销
        /// </summary>
        void DeRegister();
    }
}
