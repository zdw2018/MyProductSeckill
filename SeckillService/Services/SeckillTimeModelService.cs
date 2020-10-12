using SeckillMicroService.Context;
using SeckillMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SeckillMicroService.Services
{
   
    public class SeckillTimeModelService: ISeckillTimeModelService
    {
        private readonly ISeckillTimeModelService  _seckillTimeModelService;
        public SeckillTimeModelService(ISeckillTimeModelService  seckillTimeModelService)
        {
            this._seckillTimeModelService = seckillTimeModelService;
        }

        public void Create(SeckillTimeModel seckillTimeModel)
        {
            _seckillTimeModelService.Create(seckillTimeModel);
        }

        public void Delete(SeckillTimeModel seckillTimeModel)
        {
            _seckillTimeModelService.Delete(seckillTimeModel);
        }

        public SeckillTimeModel GetSeckillTimeModelById(int Id)
        {
            return _seckillTimeModelService.GetSeckillTimeModelById(Id);
        }

        public IEnumerable<SeckillTimeModel> GetSeckillTimeModels()
        {
            return _seckillTimeModelService.GetSeckillTimeModels();
        }

        public bool SeckillTimeModelExists(int Id)
        {
            return _seckillTimeModelService.SeckillTimeModelExists(Id);
        }

        public void Update(SeckillTimeModel seckillTimeModel)
        {
             _seckillTimeModelService.Update(seckillTimeModel);
        }
    }
}
