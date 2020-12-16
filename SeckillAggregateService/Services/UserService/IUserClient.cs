using MyProductSeckill.Core.MicroClients.Attributes;
using SeckillAggregateService.Models;
using SeckillAggregateService.Models.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeckillAggregateService.Services.UserService
{
    [MicroClient("https", "UserServices")]
    public interface IUserClient
    {
        [PostPath("/Users")]
        public User RegistryUsers(User user);
    }
}
