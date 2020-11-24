using CommonCoreService.Exceptions;
using Consul;
using Microsoft.Extensions.Options;
using SeckillCoreService.Registry.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SeckillCoreService.Registry
{
    /// <summary>
    /// 抽象服务发现 主要是缓存功能
    /// </summary>


    public abstract class AbstructServiceDiscovery : IServiceDiscovery
    {
        //字典缓存
        private readonly Dictionary<string, List<ServiceUrl>> CacheConsulResult = new Dictionary<string, List<ServiceUrl>>();
        protected readonly ServiecDiscoveryOptions serviecDiscoveryOptions;

        public AbstructServiceDiscovery(IOptions<ServiecDiscoveryOptions> options )
        {
            this.serviecDiscoveryOptions = options.Value;


            //1.创建consul客户端连接
            var consulclient = new ConsulClient(config=> {
                //1.1建立客户端与服务端的连接
                config.Address = new Uri(serviecDiscoveryOptions.DiscoveryAddress);
            });
            //2.consul先查询服务
            var queryResult = consulclient.Catalog.Services().Result;
            if(!queryResult.StatusCode.Equals(HttpStatusCode.OK))
            {
                throw new FrameException($"consul连接失败{queryResult.StatusCode}");
            }
            //3.获取服务下所以实例
            foreach (var item in queryResult.Response)
            {
                QueryResult<CatalogService[]> result = consulclient.Catalog.Service(item.Key).Result;

                if (!queryResult.StatusCode.Equals(HttpStatusCode.OK))
                {
                    throw new FrameException($"consul连接失败{queryResult.StatusCode}");
                }
                var list = new List<ServiceUrl>();
                foreach (var service in result.Response)
                {
                    list.Add(new ServiceUrl {  Url=service.ServiceAddress+":"+service.ServicePort  });
                }
                CacheConsulResult.Add(item.Key, list);

            }



            



        }
        public async Task<IList<ServiceUrl>> Discovery(string servcename)
        {
           //1.从缓存结果中查询consul结果
           if (CacheConsulResult.ContainsKey(servcename))
            {
                return CacheConsulResult[servcename];
            }
            else
            {
                //1.2从远程服务器获取
                CatalogService[] querryResult = RemoteDiscovery(servcename);

                var list = new List<ServiceUrl>();
                foreach (var service in querryResult)
                {
                    list.Add(new ServiceUrl { Url = service.ServiceAddress + ":" + service.ServicePort });
                }
                //1.3将结果添加到缓存

                CacheConsulResult.Add(servcename, list);
                return list;
            }
        }


        /// <summary>
        /// 远程服务发现
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        protected abstract CatalogService[] RemoteDiscovery(string serviceName);
    }
}
