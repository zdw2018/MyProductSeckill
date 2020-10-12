using SeckillMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeckillMicroService.Services
{
    public interface ISeckillService
    {
        IEnumerable<Seckill> GetSeckills();
        IEnumerable<Seckill> GetSeckills(Seckill seckill);
        Seckill GetSeckillById(int Id);
        Seckill GetSeckillByProductId(int productId);
        bool SeckillExists(int Id);
        void Create(Seckill seckill);
        void Update(Seckill seckill);
        void Delete(Seckill seckill);
    }
}
