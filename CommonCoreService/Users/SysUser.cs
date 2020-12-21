using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCoreService.Users
{
    /// <summary>
    /// 系统用户（用于存储用户状态相关的信息）
    /// </summary>
    public class SysUser
    {
        public int UserId { get; set; }//用户ID
        public string UserName { get; set; }//用户名称
    }
}
