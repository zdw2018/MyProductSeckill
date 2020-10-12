using SeckillMicroService.Models;
using SeckillRecordMicroService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeckillMicroService.Services
{
    public class SeckillRecordService : ISeckillRecordService
    {
        private readonly ISeckillRecordRecordRespository _seckillRecordRecordRespository;
        public SeckillRecordService(ISeckillRecordRecordRespository seckillRecordRecordRespository)
        {
            this._seckillRecordRecordRespository = seckillRecordRecordRespository;
        }
        public void Create(SeckillRecord seckillRecord)
        {
            _seckillRecordRecordRespository.Create(seckillRecord);
        }

        public void Delete(SeckillRecord seckillRecord)
        {
            _seckillRecordRecordRespository.Delete(seckillRecord);
        }

        public SeckillRecord GetSeckillRecordById(int Id)
        {
            return _seckillRecordRecordRespository.GetSeckillRecordById(Id);
        }

        public IEnumerable<SeckillRecord> GetSeckillRecords()
        {
            return _seckillRecordRecordRespository.GetSeckillRecords();
        }

        public bool SeckillRecordExists(int Id)
        {
            return _seckillRecordRecordRespository.SeckillRecordExists(Id);
        }

        public void Update(SeckillRecord seckillRecord)
        {
            _seckillRecordRecordRespository.Update(seckillRecord);
        }
    }
}
