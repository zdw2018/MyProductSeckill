using CommonCoreService.Exceptions;
using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeckillAggregateService.Dtos.UserService;
using SeckillAggregateService.Pos.UserService;
using SeckillAggregateService.Services.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SeckillAggregateService.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserClient userClient;
        public UserController(IUserClient userClient)
        {
            this.userClient = userClient;
        }
        [HttpPost("Login")]
        public UserDto PostLogin([FromForm] LoginPo loginPo)
        {
            // 1、查询用户信息 
            // 2、判断用户信息是否存在
            // 3、将用户信息生成token进行存储
            // 4、将token信息存储到cookie或者session中
            // 5、返回成功信息和token
            // 6、对于token进行认证(也就是身份认证)


            // 1、获取IdentityServer接口文档
            HttpClient client = new HttpClient();
            DiscoveryDocumentResponse discoveryDocument = client.GetDiscoveryDocumentAsync("https://localhost:5005").Result;

            if (discoveryDocument.IsError)
            {
                Console.WriteLine($"[DiscoveryDocumentResponse Error]: {discoveryDocument.Error}");
            }
            // 2、根据用户名和密码建立token
            TokenResponse tokenResponse = client.RequestPasswordTokenAsync(
                new PasswordTokenRequest
                {

                    Address = discoveryDocument.TokenEndpoint,
                    ClientId = "client-password",
                    ClientSecret = "secret",
                    GrantType = "password",
                    UserName = loginPo.UserName,
                    Password = loginPo.Password
                }).Result;
            // 3、返回AccessToken
            if (tokenResponse.IsError)
            {
                throw new BizException(tokenResponse.Error + "," + tokenResponse.Raw);
            }
            //4.返回UserDto信息
            UserDto userDto = new UserDto();


            userDto.UserName = loginPo.UserName;
            userDto.AccessToken = tokenResponse.AccessToken;
            userDto.Exprise = tokenResponse.ExpiresIn;
            return userDto;

        }
    }
}
