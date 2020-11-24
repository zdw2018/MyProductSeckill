using SeckillMicroService.Context;
using SeckillMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeckillMicroService.Repositories
{
    public class SeckillRepository : ISeckillRepository
    {
        private readonly SeckillContext _seckillContext;
        public SeckillRepository(SeckillContext seckillContext)
        {
            this._seckillContext = seckillContext;
        }
        public void Create(Seckill seckill)
        {
            _seckillContext.Set<Seckill>().Add(seckill);
            _seckillContext.SaveChanges();
        }

        public void Delete(Seckill seckill)
        {
            _seckillContext.Set<Seckill>().Remove(seckill);
            _seckillContext.SaveChanges();
        }

        public Seckill GetSeckillById(int Id)
        {
         return   _seckillContext.Set<Seckill>().Find(Id);
         
        }

        public Seckill GetSeckillByProductId(int productId)
        {
            return _seckillContext.Set<Seckill>().Where(x=>x.ProductId==productId).FirstOrDefault();
        }

        public IEnumerable<Seckill> GetSeckills()
        {
            return _seckillContext.Set<Seckill>().ToList();
        }

        public IEnumerable<Seckill> GetSeckills(Seckill seckill)
        {
            IQueryable<Seckill> query = _seckillContext.Seckills;
            if (seckill.Id != 0)
            {
                query = query.Where(s => s.Id == seckill.Id);
            }
            if (seckill.SeckillType != 0)
            {
                query = query.Where(s => s.SeckillType == seckill.SeckillType);
            }
            if (seckill.SeckillName != null)
            {
                query = query.Where(s => s.SeckillName == seckill.SeckillName);
            }
            if (seckill.SeckillUrl != null)
            {
                query = query.Where(s => s.SeckillUrl == seckill.SeckillUrl);
            }
            if (seckill.SeckillPrice != 0)
            {
                query = query.Where(s => s.SeckillPrice == seckill.SeckillPrice);
            }
            if (seckill.SeckillStock != 0)
            {
                query = query.Where(s => s.SeckillStock == seckill.SeckillStock);
            }
            if (seckill.SeckillPercent != null)
            {
                query = query.Where(s => s.SeckillPercent == seckill.SeckillPercent);
            }
            if (seckill.TimeId != 0)
            {
                query = query.Where(s => s.TimeId == seckill.TimeId);
            }
            if (seckill.ProductId != 0)
            {
                query = query.Where(s => s.ProductId == seckill.ProductId);
            }
            if (seckill.SeckillLimit != 0)
            {
                query = query.Where(s => s.SeckillLimit == seckill.SeckillLimit);
            }
            if (seckill.SeckillDescription != null)
            {
                query = query.Where(s => s.SeckillDescription == seckill.SeckillDescription);
            }
            if (seckill.SeckillIsEnd != 0)
            {
                query = query.Where(s => s.SeckillIsEnd == seckill.SeckillIsEnd);
            }
            if (seckill.SeckillStatus != 0)
            {
                query = query.Where(s => s.SeckillStatus == seckill.SeckillStatus);
            }
            return query;
        }

        public bool SeckillExists(int Id)
        {
          return _seckillContext.Set<Seckill>().Any(x => x.ProductId == Id);
        }

        public void Update(Seckill seckill)
        {
            throw new NotImplementedException();
        }
    }
}
