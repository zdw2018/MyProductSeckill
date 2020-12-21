using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreService.Filters
{
    /// <summary>
    /// 通用结果    
    /// </summary>
    public class CommonResult
    {
        public const string SUCCESS = "0";
        public string ErrorNo { get; set; }//是否成功状态
        public string ErrorInfo { get; set; }//失败信息
        public IDictionary<string, object> resultDic { get; set; }//用于非结果集返回


        public IList<IDictionary<string, object>> resultList { get; set; }//用于结果集返回


        public dynamic Result { get; set; }//返回动态结果
        public CommonResult()
        {
            resultDic = new Dictionary<string, object>();
            resultList = new List<IDictionary<string, object>>();
        }
        public CommonResult(string errorNo, string errorInfo)
        {
            this.ErrorNo = errorNo;
            this.ErrorInfo = errorInfo;
            resultDic = new Dictionary<string, object>();
            resultList = new List<IDictionary<string, object>>();
        }

        public CommonResult(string errorNo, string erroInfo, IDictionary<string, object> resultDic, IList<IDictionary<string, object>> resultList) : this(errorNo, erroInfo)
        {
            this.resultDic = resultDic;
            this.resultList = resultList;
            this.resultDic = resultDic;
            this.resultList = resultList;
        }
    }
}
