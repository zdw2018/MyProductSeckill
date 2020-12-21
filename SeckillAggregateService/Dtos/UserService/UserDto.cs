using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeckillAggregateService.Dtos.UserService
{
    /// <summary>
    /// 用户登陆成功给返回的信息
    /// </summary>
    public class UserDto
    {
        public string AccessToken { get; set; }//执行Token(用户身份)
        public int Exprise { get; set; }//AccressToken过期时间
        public string UserName { get; set; }//用户名
    }
}
