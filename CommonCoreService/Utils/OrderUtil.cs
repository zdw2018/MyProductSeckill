using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreService.Utils
{
    /// <summary>
    /// 订单号工具类
    /// </summary>
   public class OrderUtil
    {
        //订单前缀
        private const string PREFIX = "ZDW";
        //订单编号后缀
        private static long code;
        private static object lockobject = new object();
        public static string GetOrderCode()
        {
            lock(lockobject)
            {
                code++;
                string str = string.Format("{0:yyyyMMddmmss}",DateTime.Now);
                long m = long.Parse(str)*10000;
                m += code;
                return PREFIX + m;
            }
        }

    }
}
