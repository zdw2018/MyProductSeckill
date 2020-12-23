using Microsoft.Extensions.Options;
using MyProductSeckill.Core.Registry.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Consul;

namespace MyProductSeckill.Core.Registry.Consul
{
    /// <summary>
    /// 服务注册实现
    /// </summary>
    public class ConsulServiceRegistry : IServiceRegistry
    {
        public readonly ServiceRegistryOptions serviceRegistryOptions;
        public ConsulServiceRegistry(IOptions<ServiceRegistryOptions> options)
        {
            this.serviceRegistryOptions = options.Value;
        }
        //注册服务
        public void Register()
        {

            //1.创建consul客户端
            var consulClient = new ConsulClient(config =>
            {
                //1. 建立客户端连接
                config.Address = new Uri(serviceRegistryOptions.RegistryAddress);
            });
            //2.获取

            var uri = new Uri(serviceRegistryOptions.ServiceAddress);
            //3.创建consul服务注册对象
            var registeration = new AgentServiceRegistration()
            {
                ID = string.IsNullOrEmpty(serviceRegistryOptions.ServiceId) ? Guid.NewGuid().ToString() : serviceRegistryOptions.ServiceId,
                Name = serviceRegistryOptions.ServiceName,
                Address = uri.Host,
                Port = uri.Port,
                Tags = serviceRegistryOptions.ServiceTag,
                Check = new AgentServiceCheck
                {
                    // 3.1、consul健康检查超时间
                    Timeout = TimeSpan.FromSeconds(10),
                    //3.2、服务停止5秒后注销服务
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),
                    //3.3、consul健康检查地址
                    HTTP = $"{uri.Scheme}://{uri.Host}:{uri.Port}{serviceRegistryOptions.HealthCheckAddresss}",
                    // 3.4 consul健康检查间隔时间
                    Interval = TimeSpan.FromSeconds(10)
                }
            };
            //4.注册服务
            consulClient.Agent.ServiceRegister(registeration).Wait();
            Console.WriteLine($"服务注册成功:{serviceRegistryOptions.ServiceAddress}");
            //关闭
            consulClient.Dispose();
        }

        public void DeRegister()
        {
            //1.建立客户端连接
            var consulClient = new ConsulClient(config =>
            {
                config.Address = new Uri(serviceRegistryOptions.RegistryAddress);

            });
            //2.注销服务
            consulClient.Agent.ServiceDeregister(serviceRegistryOptions.ServiceId).Wait();
            Console.WriteLine($"服务注销成功:{serviceRegistryOptions.ServiceAddress}");
            //3.关闭连接
            consulClient.Dispose();
        }
    }
}
