using SeckillMicroService.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeckillMicroService.Repositories
{
   
    public class SeckillTimeModelRespository
    {
        private readonly SeckillContext _seckillContext;
        public SeckillTimeModelRespository(SeckillContext seckillContext)
        {
            this._seckillContext = seckillContext;
        }

    }
}
