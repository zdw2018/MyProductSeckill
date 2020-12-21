using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonCoreService.Filters
{
    public class FrontResultWapper : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (context.Result is ObjectResult objectResult)
            {
                int? statusCode = objectResult.StatusCode;
                if (statusCode == 200 || statusCode == 201 || statusCode == 202 || !statusCode.HasValue)
                {
                    objectResult.Value = WrapSuccessResult(objectResult.Value);
                }
                else
                {
                    objectResult.Value = WrapFailResult(objectResult);
                }
            }
            await next();
        }
        /// <summary>
        /// 包装异常结果
        /// </summary>
        /// <returns></returns>
        private object WrapFailResult(ObjectResult objectResult)
        {
            dynamic wrapResult = new ExpandoObject();
            wrapResult.ErrorNo = objectResult.StatusCode;
            if (objectResult.Value is string info)
            {
                //1.字符串异常信息
                wrapResult.ErrorInfo = info;
            }
            else
            {
                //2.类型异常信息
                wrapResult.ErrorInfo = new JsonResult(objectResult.Value).Value;
            }
            return wrapResult;
        }
        /// <summary>
        /// 包装正常结果
        /// </summary>
        /// <returns></returns>
        private object WrapSuccessResult(object value)
        {
            //1.创建返回结果
            dynamic warpResult = new ExpandoObject();
            warpResult.ErrorNo = "0";
            warpResult.ErrorInfo = "";
            //2.获取结果(输出到页面：结果集List<>，非结果集Dic)
            if (value.GetType().Name.Contains("List"))
            {
                //转换成json
                warpResult.ResultList = new JsonResult(value).Value;
            }
            else if (value.GetType().Name.Contains("Dictionary"))
            {
                //2.1判断是否含有ErrorInfo
                IDictionary dictionary = (IDictionary)value;
                if (dictionary.Contains("ErrorInfo"))
                {
                    warpResult.ErrorInfo = dictionary["ErrorInfo"];
                    warpResult.ErrorNo = dictionary["ErrorNo"];
                    //2.删除字典里里面的 ErrorInfo ErrorNo
                    dictionary.Remove("ErrorNo");
                    dictionary.Remove("ErrorInfo");
                }
                warpResult.ResultDic = new JsonResult(value).Value;
            }
            else
            {
                warpResult.ResultDic = new JsonResult(value).Value;
            }
            return warpResult;
        }
        private IDictionary<string, object> ToDictionary(object value)
        {
            IDictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            //获取反射类型
            Type type = value.GetType();
            //2.获取反射属性
            PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var item in propertyInfos)
            {
                keyValuePairs.Add(item.Name, Convert.ToString(item.GetValue(value)));
            }
            return keyValuePairs;
        }
    }
}
