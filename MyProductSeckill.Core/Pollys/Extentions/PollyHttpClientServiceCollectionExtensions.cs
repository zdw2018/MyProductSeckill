using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Net;
using MyProductSeckill.Core.HttpClientPolic;
using System.Threading.Tasks;

namespace MyProductSeckill.Core.Pollys.Extentions
{
    /// <summary>
    /// 微服务中HttpClient熔断 降级策略扩展
    /// </summary>
    public static class PollyHttpClientServiceCollectionExtensions
    {

        public static IServiceCollection AddPollyClient(this IServiceCollection services, string name, Action<PollyHttpClientOptions> action)
        {
            //创建 选项配置表
            PollyHttpClientOptions options = new PollyHttpClientOptions();
            action(options);
            var fallbackResponse = new HttpResponseMessage
            {
                //降级消息
                Content = new StringContent(options.ResponseMessage),
                //降级状态码
                StatusCode = HttpStatusCode.GatewayTimeout
            };
            //2.配置 httpclient熔断降级策略
            object addPolicyHandler = services.AddHttpClient(name)
           //1.降级策略
           .AddPolicyHandler(Policy<HttpResponseMessage>.HandleInner<Exception>().FallbackAsync(fallbackResponse, async b =>
           {

               //1.降级打印
               Console.WriteLine($"服务{name}开始降级，异常消息：{b.Exception.Message}");
               //2.降级后的数据
               Console.WriteLine($"服务{name}降级内容响应:{fallbackResponse.RequestMessage}");
               await Task.CompletedTask;
           }))
           //2.熔断策略
           .AddPolicyHandler(Policy<HttpResponseMessage>.Handle<Exception>().CircuitBreakerAsync(options.CircuitBreakerOpenFallCount, TimeSpan.FromSeconds(options.CircuitBreakerDownTime), (ex, ts) =>
             {
                 Console.WriteLine($"服务{name}断路器开启，异常消息:{ex.Exception.Message}");

                 Console.WriteLine($"服务{name}断路器开启时间:{ts.TotalSeconds}s");

             }, () =>
             {
                 Console.WriteLine($"服务{name}断路器关闭");

             }, () =>
             {

                 Console.WriteLine($"服务{name}断路器半开启（时间控制，自动开启）");
             }))
             //3.重试策略
             .AddPolicyHandler(Policy<HttpResponseMessage>.Handle<Exception>().RetryAsync(options.RetryCount))
             //4.超时策略
             .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(options.TimeOut)));
            return services;

        }
    }
}
