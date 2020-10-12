using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CommonCoreService.Utils
{
    public class DictionaryUtil
    {
        public IDictionary<string,object> ToDictionary(object value)
        {
            IDictionary<string, object> keyValuePairs = new Dictionary<string, object>();
            //获取反射类型
            Type type = value.GetType();
            // 2、获取所有反射属性
            PropertyInfo[] propertyInfos = type.GetProperties( BindingFlags.Public|BindingFlags.Instance);

            // 3、遍历PropertyInfo
            foreach (PropertyInfo info in propertyInfos)
            {
                keyValuePairs.Add(info.Name, Convert.ToString(info.GetValue(value)));
            }
            return keyValuePairs;
        }
    }
}
