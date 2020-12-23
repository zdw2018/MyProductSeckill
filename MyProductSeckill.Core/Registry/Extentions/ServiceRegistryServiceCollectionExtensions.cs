using Microsoft.Extensions.DependencyInjection;
using MyProductSeckill.Core.Registry.Consul;
using MyProductSeckill.Core.Registry.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProductSeckill.Core.Registry.Extentions
{
    /// <summary>
    /// 服务注册IOC容器扩展
    /// </summary>
    public static class ServiceRegistryServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceRegistry(this IServiceCollection services)
        {
            AddServiceRegistry(services, Options => { });
            return services;
        }
        public static IServiceCollection AddServiceRegistry(this IServiceCollection services, Action<ServiceRegistryOptions> options)
        {

            //1 配置选项到IOC
            services.Configure<ServiceRegistryOptions>(options);
            //2. 注册consul
            services.AddSingleton<IServiceRegistry, ConsulServiceRegistry>();
            //3.注册consul开机自动注册服务
            services.AddHostedService<ServiceRegistryIHostedService>();
            return services;
        }
    }
}
