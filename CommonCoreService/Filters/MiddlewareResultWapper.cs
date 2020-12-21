using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace CommonCoreService.Filters
{
    /// <summary>
    /// 通用结果包装
    /// </summary>
    public class MiddlewareResultWapper : IAsyncResultFilter
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


        private object WrapSuccessResult(object value)
        {
            //1.创建返回结果
            dynamic wrapResult = new ExpandoObject();
            wrapResult.ErrorNo = "0";
            wrapResult.ErrorInfo = "";
            //2.判断是否为字典
            if (value.GetType().Name.Contains("Dictionary"))
            {
                IDictionary dictionary = (IDictionary)value;
                if (dictionary.Contains("ErrorInfo"))
                {
                    wrapResult.ErrorNo = dictionary["ErrorNo"];
                    wrapResult.ErrorInfo = dictionary["ErrorInfo"];
                    //2.2删除字典的ErrornO 
                    dictionary.Remove("ErrorNo");
                    dictionary.Remove("ErrorInfo");
                }
            }
            wrapResult.Result = new JsonResult(value).Value;
            return wrapResult;

        }
    }
}
