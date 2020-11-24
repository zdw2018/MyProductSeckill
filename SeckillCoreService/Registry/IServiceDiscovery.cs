using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SeckillCoreService.Registry
{
    /// <summary>
    /// 服务发现
    /// </summary>
   public interface IServiceDiscovery
    {
        /// <summary>
        /// 服务发现
        /// </summary>
        /// <param name="servcename">服务名称</param>
        /// <returns></returns>
        Task<IList<ServiceUrl>> Discovery(string servcename);
    }
}
