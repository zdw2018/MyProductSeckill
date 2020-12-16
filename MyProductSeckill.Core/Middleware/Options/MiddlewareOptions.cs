using System;
using System.Collections.Generic;
using System.Text;
using MyProductSeckill.Core.HttpClientPolic;

namespace MyProductSeckill.Core.Middleware.Options
{
    public class MiddlewareOptions
    {
        public MiddlewareOptions()
        {
            this.HttpClientName = "Micro";

        }
        /// <summary>
        /// polly熔断降级选项
        /// </summary>
        public Action<PollyHttpClientOptions> PollyHttpClientOptions { get; }
        /// <summary>
        /// 客户端名称
        /// </summary>
        public string HttpClientName { get; set; }

    }
}
