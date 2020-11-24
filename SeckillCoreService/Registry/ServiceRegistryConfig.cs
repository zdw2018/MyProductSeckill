using System;
using System.Collections.Generic;
using System.Text;

namespace SeckillCoreService.Registry
{
    /// <summary>
    /// 服务注册节点
    /// </summary>
    public class ServiceRegistryConfig
    {
        public ServiceRegistryConfig()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Name = "";
            this.Address = "";
            this.RegistryAddress = "http://localhost:8500";
            this.HealthCheckAddress = "";

        }


    
        // 服务ID        
        public string Id { get; set; }
        //服务名称
        public string Name { get; set; }
        //服务标签（版本）
        public string[] Tags { get; set; }
        //服务地址（可以选填===默认加载启动路径（localhost））
        public string Address { get; set; }
        //服务端口号（可以选填===默认记载启动端口）
        public int Port { get; set; }
        //服务注册地址
        public string RegistryAddress { get; set; }
        //服务健康检查地址
        public string HealthCheckAddress { get; set; }
    }
  
}
