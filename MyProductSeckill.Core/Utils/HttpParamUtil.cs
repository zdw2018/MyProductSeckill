using System;
using System.Collections.Generic;
using System.Text;

namespace MyProductSeckill.Core.Utils
{
    public class HttpParamUtil
    {
        public static string DicToHttpUrlParam(IDictionary<string, object> middleParam)
        {
            if (middleParam.Count != 0)
            {
                //1.拼接
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("?");
                foreach (var item in middleParam)
                {
                    stringBuilder.Append(item.Key);
                    stringBuilder.Append("=");
                    stringBuilder.Append(item.Value);
                    stringBuilder.Append("&");
                }
                //2/截取去掉最后一个“&”
                string UrlParam = stringBuilder.ToString();
                UrlParam = UrlParam.Substring(0, UrlParam.Length - 1);
                return UrlParam;
            }
            return "";
        }
    }
}
