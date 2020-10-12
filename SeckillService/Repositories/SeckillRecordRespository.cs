using SeckillMicroService.Context;
using SeckillMicroService.Models;
using SeckillRecordMicroService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeckillMicroService.Repositories
{
    public class SeckillRecordService : ISeckillRecordRecordRespository
    {
        private readonly SeckillContext _seckillContext;
        public SeckillRecordService(SeckillContext seckillContext)
        {
            this._seckillContext = seckillContext;
        }
        public void Create(SeckillRecord seckillRecord)
        {
            _seckillContext.Set<SeckillRecord>().Add(seckillRecord);
            _seckillContext.SaveChanges();
        }

        public void Delete(SeckillRecord seckillRecord)
        {
            _seckillContext.Set<SeckillRecord>().Remove(seckillRecord);
            _seckillContext.SaveChanges();
        }

        public SeckillRecord GetSeckillRecordById(int Id)
        {
           return _seckillContext.Set<SeckillRecord>().Find(Id);
           
        }

        public IEnumerable<SeckillRecord> GetSeckillRecords()
        {
            return _seckillContext.Set<SeckillRecord>().ToList();
        }

        public bool SeckillRecordExists(int Id)
        {
            return _seckillContext.Set<SeckillRecord>().Any(x=>x.Id==Id);
        }

        public void Update(SeckillRecord seckillRecord)
        {
            _seckillContext.Set<SeckillRecord>().Remove(seckillRecord);
            _seckillContext.SaveChanges();
        }
    }
}
