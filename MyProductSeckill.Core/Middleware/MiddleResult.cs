using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProductSeckill.Core.Middleware
{
    public class MiddleResult
    {
        public const string SUCCESS = "0";
        //是否成功状态
        public string ErrorNo { get; set; }
        //失败信息
        public string ErrorInfo { get; set; }
        //非结果集返回
        public IDictionary<string, object> ResultDic { get; set; }
        //结果集返回
        public IList<IDictionary<string, object>> ResultList { get; set; }
        //返回动态结果
        public dynamic Result { get; set; }
        public MiddleResult()
        {
            ResultDic = new Dictionary<string, object>();
            ResultList = new List<IDictionary<string, object>>();
        }
        public MiddleResult(string jsonStr)
        {
            MiddleResult result = JsonConvert.DeserializeObject<MiddleResult>(jsonStr);
        }
        /// <summary>
        /// 中台结果串转化为MiddleResult
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public static MiddleResult JsonToMiddleResult(string jsonStr)
        {
            MiddleResult result = JsonConvert.DeserializeObject<MiddleResult>(jsonStr);
            return result;
        }
        public MiddleResult(string errorNo, string errorInfo)
        {
            this.ErrorNo = errorNo;
            this.ErrorInfo = errorInfo;
            this.ResultDic = new Dictionary<string, object>();
            this.ResultList = new List<IDictionary<string, object>>();
        }
        public MiddleResult(string errorNo, string errorInfo, IDictionary<string, object> resultDic, IList<IDictionary<string, object>> resultList)
        {
            this.ErrorNo = errorNo;
            this.ErrorInfo = errorInfo;
            this.ResultDic = resultDic;
            this.ResultList = resultList;
        }
    }
}
