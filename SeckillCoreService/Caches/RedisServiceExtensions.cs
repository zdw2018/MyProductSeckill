using CSRedis;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SeckillCoreService.Caches
{
    public static class RedisServiceExtensions
    {
        public static IServiceCollection AddRedis(this IServiceCollection service)
        {
            var csredis = new CSRedisClient("127.0.0.1:6379,password=,defaultDatabase=2,poolsize=50,connectionTimeout=5000,syncTimeout=10000,perfix=cs_redis_:$$$");

            service.AddSingleton(csredis);
            RedisHelper.Initialization(csredis);
            return service;


        }
    }
}
