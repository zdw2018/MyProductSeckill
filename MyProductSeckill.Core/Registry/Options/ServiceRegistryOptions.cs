using System;
using System.Collections.Generic;
using System.Text;

namespace MyProductSeckill.Core.Registry.Options
{
    public class ServiceRegistryOptions
    {
        public ServiceRegistryOptions()
        {
            this.ServiceId = Guid.NewGuid().ToString();
            this.RegistryAddress = "https://localhost:8500";
            this.HealthCheckAddresss = "/HealthCheck";
        }
        /// <summary>
        /// 服务ID
        /// </summary>
        public string ServiceId { get; set; }
        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// 服务地址
        /// </summary>
        public string ServiceAddress { get; set; }

        /// <summary>
        /// 服务标签
        /// </summary>
        public string[] ServiceTag { get; set; }
        /// <summary>
        /// 注册中心地址
        /// </summary>
        public string RegistryAddress { get; set; }
        /// <summary>
        /// 健康检查地址
        /// </summary>
        public string HealthCheckAddresss { get; set; }
    }
}
