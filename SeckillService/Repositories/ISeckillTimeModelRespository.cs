using SeckillMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeckillMicroService.Repositories
{
    public interface ISeckillTimeModelService
    {
        IEnumerable<SeckillTimeModel> GetSeckillTimeModels();
        SeckillTimeModel GetSeckillTimeModelById(int Id);
        bool SeckillTimeModelExists(int Id);
        void Create(SeckillTimeModel seckillTimeModel);
        void Update(SeckillTimeModel seckillTimeModel);
        void Delete(SeckillTimeModel seckillTimeModel);
    }
}
