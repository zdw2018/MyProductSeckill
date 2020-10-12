using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace CommonCoreService.Exceptions.Handlers
{
    public class BizExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // 1、判断异常是否BizException
            if (context.Exception is BizException bizException )
            {
                dynamic exceptionResult = new ExpandoObject();
                exceptionResult.ErrorNo = bizException.ErrorNo;
                exceptionResult.ErrorInfo = bizException.ErrorInfo;
                if(bizException.Infos!=null)
                {
                    exceptionResult.Infos = bizException.Infos;
                }
                context.Result = new JsonResult(exceptionResult);
            }
            else
            {
                // 1.2 处理其他类型异常Exception
                dynamic exceptionResult = new ExpandoObject();
                exceptionResult.ErrorNo = -1;
                exceptionResult.ErrorInfo = context.Exception.Message;
                context.Result = new JsonResult(exceptionResult);
            }
        }
    }
}
