using Microsoft.Extensions.DependencyInjection;
using MyProductSeckill.Core.Registry.Consul;
using MyProductSeckill.Core.Registry.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProductSeckill.Core.Registry.Extentions
{
    public static class ServiceDiscoverySercviceCollectionExtensions
    {
        public static IServiceCollection AddServiceDiscovery(this IServiceCollection services)
        {
            //1 注册consul服务发现
            AddServiceDiscovery(services, options => { });
            return services;
        }
        public static IServiceCollection AddServiceDiscovery(this IServiceCollection services, Action<ServiceDiscoveryOptions> options)
        {
            //2.注册到Ioc容器
            services.Configure<ServiceDiscoveryOptions>(options);
            //3.注册consul服务发现
            services.AddSingleton<IServiceDiscovery, ConsulServiceDiscovery>();
            return services;
        }
    }
}
