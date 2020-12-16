using System;
using System.Collections.Generic;
using System.Text;

namespace MyProductSeckill.Core.HttpClientPolic
{
    /// <summary>
    /// HttpClient熔断降级策略选项
    /// </summary>
    public class PollyHttpClientOptions
    {
        public PollyHttpClientOptions()
        {
            this.TimeOut = 60;
            this.RetryCount = 3;
            this.CircuitBreakerOpenFallCount = 2;
            this.CircuitBreakerDownTime = 5;
            this.ResponseMessage = "服务熔断降级了~~~~~~";
        }
        /// <summary>
        /// 超时时间设置（秒）
        /// </summary>
        public int TimeOut { get; set; }
        /// <summary>
        /// 失败重试次数
        /// </summary>
        public int RetryCount { get; set; }
        /// <summary>
        /// 执行多少次异常 开启短路器（例:失败两次开启断路器）
        /// </summary>
        public int CircuitBreakerOpenFallCount { get; set; }
        /// <summary>
        /// 断路器开启时间（例如：设置为2秒 短路器两秒后自动由开启到关闭）
        /// </summary>
        public int CircuitBreakerDownTime { get; set; }
        /// <summary>
        /// 降级处理（将异常消息封装成 正常消息返回 然后正常处理 例如：系统正在繁忙，请稍后处理。。。。。）
        /// </summary>
        public string ResponseMessage { get; set; }

    }
}
