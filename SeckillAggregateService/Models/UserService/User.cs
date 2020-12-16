using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SeckillAggregateService.Models.UserService
{
    /// <summary>
    /// 用户模型
    /// </summary>
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }//用户名
        public string PassWord { get; set; }//密码
        public string UserNickName { get; set; }//昵称
        public string UserQQ { get; set; }//qq
        public DateTime Createtime { get; set; }//创建时间
        public string UserPhone { get; set; }//手机号

    }
}
