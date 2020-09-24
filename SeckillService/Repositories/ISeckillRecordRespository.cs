using SeckillMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeckillRecordMicroService.Repositories
{
  public  interface ISeckillRecordRecordRespository
    {
        IEnumerable<SeckillRecord> GetSeckillRecords();
        //IEnumerable<SeckillRecord> GetSeckillRecords(SeckillRecord seckillRecord);
        SeckillRecord GetSeckillRecordById(int Id);
        //SeckillRecord GetSeckillRecordByProductId(int productId);
        bool SeckillRecordExists(int Id);
        void Create(SeckillRecord seckillRecord);
        void Update(SeckillRecord seckillRecord);
        void Delete(SeckillRecord seckillRecord);
    }
}
