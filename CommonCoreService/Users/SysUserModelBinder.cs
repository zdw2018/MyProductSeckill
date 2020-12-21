using CommonCoreService.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CommonCoreService.Users
{
    public class SysUserModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
            if (bindingContext.ModelType == typeof(SysUser))
            {
                //1.转换到指定模型
                SysUser sysUser = new SysUser();

                //2.设置指定模型
                HttpContext httpContext = bindingContext.HttpContext;
                ClaimsPrincipal claimsPrincipal = httpContext.User;
                IEnumerable<Claim> claims = claimsPrincipal.Claims;
                //1.判断声明是否为空如果为空 没有登录 抛出异常
                if (claims.ToList().Count == 0)
                {
                    throw new BizException("授权失败，没有登录");
                }
                foreach (var item in claims)
                {
                    //1.获取用户ID
                    if (item.Type.Contains("sub"))
                    {
                        sysUser.UserId = Convert.ToInt32(item.Value);
                    }
                    // 2、获取用户名
                    if (item.Type.Equals("amr"))
                    {
                        sysUser.UserName = item.Value;
                    }
                }
                //3.返回结果
                bindingContext.Result = ModelBindingResult.Success(sysUser);
            }
            return Task.CompletedTask;
        }
    }
}
