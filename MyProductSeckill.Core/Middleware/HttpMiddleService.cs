using CommonCoreService.Exceptions;
using MyProductSeckill.Core.Utils;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace MyProductSeckill.Core.Middleware
{
    public class HttpMiddleService : IMiddleService
    {
        private IHttpClientFactory httpClientFactory;
        private const string HttpConst = "micro";
        public HttpMiddleService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        private MiddleResult GetMiddleResult(HttpResponseMessage httpResponseMessage)
        {
            // 将HttpResponseMessage转化为MiddleResult
            if (httpResponseMessage.StatusCode.Equals(HttpStatusCode.OK) || httpResponseMessage.StatusCode.Equals(HttpStatusCode.Created) || httpResponseMessage.StatusCode.Equals(HttpStatusCode.Accepted))
            {
                string httpJsonString = httpResponseMessage.Content.ReadAsStringAsync().Result;
                return MiddleResult.JsonToMiddleResult(httpJsonString);
            }
            else
            {
                throw new FrameException($"{HttpConst}服务调用错误：{httpResponseMessage.Content.ReadAsStringAsync().ToString()}");
            }
        }
        public MiddleResult Delete(string middleUrl, IDictionary<string, object> middleParam)
        {
            //1.获取httpclient
            HttpClient httpClient = httpClientFactory.CreateClient(HttpConst);
            //2.Delete请求
            HttpResponseMessage httpResponseMessage = httpClient.DeleteAsync(middleUrl).Result;

            return GetMiddleResult(httpResponseMessage);
        }

        public MiddleResult Get(string middleUrl, IDictionary<string, object> middleParam)
        {
            //1.获取httpclient
            HttpClient httpClient = httpClientFactory.CreateClient(HttpConst);
            //2.参数转化为url
            string urlparam = HttpParamUtil.DicToHttpUrlParam(middleParam);
            //2.Get
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(middleUrl + urlparam).Result;

            return GetMiddleResult(httpResponseMessage);
        }

        public MiddleResult Post(string middleUrl, IDictionary<string, object> middleParam)
        {
            //1.获取httpclient
            HttpClient httpClient = httpClientFactory.CreateClient(HttpConst);
            //2.转化json参数            
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(middleParam), Encoding.UTF8, "application/json");
            //2.Post
            HttpResponseMessage httpResponseMessage = httpClient.PostAsync(middleUrl, httpContent).Result;
            return GetMiddleResult(httpResponseMessage);
        }

        public MiddleResult Post(string middleUrl, IList<IDictionary<string, object>> middleParams)
        {
            //1.获取httpclient
            HttpClient httpClient = httpClientFactory.CreateClient(HttpConst);
            //2.转化json参数


            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(middleParams), Encoding.UTF8, "application/json");
            //2.Post
            HttpResponseMessage httpResponseMessage = httpClient.PostAsync(middleUrl, httpContent).Result;

            return GetMiddleResult(httpResponseMessage);
        }

        public MiddleResult PostDynamic(string middleUrl, dynamic middleParam)
        {
            //1.获取httpclient
            HttpClient httpClient = httpClientFactory.CreateClient(HttpConst);
            //2.转化json参数

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(middleParam), Encoding.UTF8, "application/json");
            //2.Post
            HttpResponseMessage httpResponseMessage = httpClient.PostAsync(middleUrl, httpContent).Result;

            return GetMiddleResult(httpResponseMessage);
        }

        public MiddleResult Put(string middleUrl, IDictionary<string, object> middleParam)
        {
            //1.获取httpclient
            HttpClient httpClient = httpClientFactory.CreateClient(HttpConst);
            //2.转化json参数

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(middleParam), Encoding.UTF8, "application/json");
            //2.put
            HttpResponseMessage httpResponseMessage = httpClient.PutAsync(middleUrl, httpContent).Result;

            return GetMiddleResult(httpResponseMessage);
        }

        public MiddleResult Put(string middleUrl, IList<IDictionary<string, object>> middleParams)
        {
            //1.获取httpclient
            HttpClient httpClient = httpClientFactory.CreateClient(HttpConst);
            //2.转化json参数

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(middleParams), Encoding.UTF8, "application/json");
            //2.put
            HttpResponseMessage httpResponseMessage = httpClient.PutAsync(middleUrl, httpContent).Result;

            return GetMiddleResult(httpResponseMessage);
        }

        public MiddleResult PutDynamic(string middleUrl, dynamic middleParam)
        {
            //1.获取httpclient
            HttpClient httpClient = httpClientFactory.CreateClient(HttpConst);
            //2.转化json参数

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(middleParam), Encoding.UTF8, "application/json");
            //2.put
            HttpResponseMessage httpResponseMessage = httpClient.PutAsync(middleUrl, httpContent).Result;

            return GetMiddleResult(httpResponseMessage);
        }
    }
}
