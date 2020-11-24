using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreService.Exceptions
{
    public class FrameException : Exception
    {
        public string ErrorNo { get; set; }//业务异常编号
        public string ErrorInfo { get; set; }//业务异常信息
        public IDictionary<string,object> Infos { get; set; }//业务异常详情
        public FrameException(string errorNo,string errorInfo):base(errorInfo)
        {
            this.ErrorNo = errorNo;
            this.ErrorInfo = errorInfo;
        }
        public FrameException(string errorNo, string errorInfo, Exception e) : base(errorInfo, e)
        {
            ErrorNo = errorNo;
            ErrorInfo = errorInfo;
        }

        public FrameException(string errorInfo) : base(errorInfo)
        {
            ErrorNo = "-1";
            ErrorInfo = errorInfo;
        }

        public FrameException(string errorInfo, Exception e) : base(errorInfo, e)
        {
            ErrorNo = "-1";
            ErrorInfo = errorInfo;
        }

        public FrameException(Exception e)
        {
            ErrorNo = "-1";
            ErrorInfo = e.Message;
        }
    }
}
