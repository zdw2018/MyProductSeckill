using Microsoft.Extensions.DependencyInjection;
using MyProductSeckill.Core.Middleware.Options;
using MyProductSeckill.Core.Pollys.Extentions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProductSeckill.Core.Middleware.Extentions
{
    /// <summary>
    /// 中台ServiceCollection扩展方法
    /// </summary>
    public static class MiddlewareServiceCollectionExtentions
    {
        public static IServiceCollection AddMiddleware(this IServiceCollection services)
        {
            AddMiddleware(services, Options => { });
            return services;
        }

        public static IServiceCollection AddMiddleware(this IServiceCollection services, Action<MiddlewareOptions> options)
        {
            MiddlewareOptions middlewareOptions = new MiddlewareOptions();
            options(middlewareOptions);

            //注册到IOC
            services.Configure<MiddlewareOptions>(options);

            //添加带HttpClient
            services.AddPollyClient(middlewareOptions.HttpClientName, middlewareOptions.PollyHttpClientOptions);
            //注册中台
            services.AddSingleton<IMiddleService, HttpMiddleService>();
            return services;

        }
    }
}
