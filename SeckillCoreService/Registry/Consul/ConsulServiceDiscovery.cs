using CommonCoreService.Exceptions;
using Consul;
using Microsoft.Extensions.Options;
using SeckillCoreService.Registry.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SeckillCoreService.Registry.Consul
{
    //consul服务发现
    public class ConsulServiceDiscovery : AbstructServiceDiscovery
    {
        public ConsulServiceDiscovery(IOptions<ServiecDiscoveryOptions> option) : base(option)
        {

        }
        protected override CatalogService[] RemoteDiscovery(string serviceName)
        {
            //1.创建服务客户端
            var consulclient = new ConsulClient(config =>
            {
                //1.1建立客户端和服务端的连接

                config.Address = new Uri(serviecDiscoveryOptions.DiscoveryAddress);

            });
            //2. consul查询服务，根据具体的服务名称查询
            var queryResult = consulclient.Catalog.Service(serviceName).Result;
            //3. 判断请求是否失败
            if(!queryResult.StatusCode.Equals(HttpStatusCode.OK))
            {
                throw new FrameException($"consul连接失败:{queryResult.StatusCode}");
            }
            return queryResult.Response;
        }
    }
}
