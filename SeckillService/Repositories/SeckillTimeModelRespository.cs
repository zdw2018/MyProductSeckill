using SeckillMicroService.Context;
using SeckillMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SeckillMicroService.Repositories
{
   
    public class SeckillTimeModelService: ISeckillTimeModelService
    {
        private readonly SeckillContext _seckillContext;
        public SeckillTimeModelService(SeckillContext seckillContext)
        {
            this._seckillContext = seckillContext;
        }

        public void Create(SeckillTimeModel seckillTimeModel)
        {
            _seckillContext.Set<SeckillTimeModel>().Add(seckillTimeModel);
            _seckillContext.SaveChanges();
        }

        public void Delete(SeckillTimeModel seckillTimeModel)
        {
            _seckillContext.Set<SeckillTimeModel>().Remove(seckillTimeModel);
            _seckillContext.SaveChanges();
        }

        public SeckillTimeModel GetSeckillTimeModelById(int Id)
        {
            return _seckillContext.Set<SeckillTimeModel>().Find(Id);
        }

        public IEnumerable<SeckillTimeModel> GetSeckillTimeModels()
        {
            return _seckillContext.Set<SeckillTimeModel>().ToList();
        }

        public bool SeckillTimeModelExists(int Id)
        {
            return _seckillContext.Set<SeckillTimeModel>().Any(x => x.Id == Id);
        }

        public void Update(SeckillTimeModel seckillTimeModel)
        {
            _seckillContext.Set<SeckillTimeModel>().Update(seckillTimeModel);
            _seckillContext.SaveChanges();
        }
    }
}
