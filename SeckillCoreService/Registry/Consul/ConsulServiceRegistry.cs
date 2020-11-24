using Consul;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeckillCoreService.Registry.Consul
{
    /// <summary>
    /// consul注册服务实现
    /// </summary>
    public class ConsulServiceRegistry : IServiceRegistery
    {
        /// <summary>
        /// 服务注销
        /// </summary>
        /// <param name="serviceNode"></param>
        public void DeRegister(ServiceRegistryConfig serviceNode)
        {
            //1，创建客户端连接
            var consulclient = new ConsulClient(config=> {
                //1.1建立客户端与服务端的连接
                config.Address = new Uri(serviceNode.Address);            
            });
            //2.注销服务
            consulclient.Agent.ServiceDeregister(serviceNode.Id);
            //3 关闭连接
            consulclient.Dispose();
        }
        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="serviceNode"></param>
        public void Register(ServiceRegistryConfig serviceNode)
        {
            //1.创建服务客户端


            var consulclient = new ConsulClient(config =>
            {
                //1.1 建立客户端与服务端的连接
                config.Address = new Uri(serviceNode.Address);

            });
            //2.获取服务内部地址

            //3.创建consul服务注册对象
            var registeration = new AgentServiceRegistration()
            {

                Address = serviceNode.Address,
                ID = serviceNode.Id,
                Name = serviceNode.Name,
                Port = serviceNode.Port,
                Tags = serviceNode.Tags,
                Check = new AgentServiceCheck
                {
                    //3.1 consul健康检查超时时间
                    Timeout = TimeSpan.FromSeconds(10),
                    //3.2 服务停止5秒后注销服务
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),
                    //3.3 consul健康检查地址
                    HTTP = serviceNode.HealthCheckAddress,
                    // 3.4 健康检查时间间隔
                    Interval = TimeSpan.FromSeconds(10)
                },
            };
            //4.注册服务
            consulclient.Agent.ServiceRegister(registeration).Wait();
            //5.关闭连接
            consulclient.Dispose();

        }
    }
}
