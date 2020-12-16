using Microsoft.AspNetCore.Mvc;
using SeckillMicroService.Services;
using SeckillMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SeckillMicroService.Controllers
{
    //秒杀服务记录控制器
    [Route("Seckill/{SeckillId}/SeckillRecords")]
    [ApiController]
    public class SeckillRecordController : ControllerBase
    {
        private readonly ISeckillRecordService _seckillRecordService;

        public SeckillRecordController(ISeckillRecordService seckillRecordService)
        {
            this._seckillRecordService = seckillRecordService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SeckillRecord>> GetSeckillRecords()
        {
            return _seckillRecordService.GetSeckillRecords().ToList();
        }


        [HttpGet("{id}")]
        public ActionResult<SeckillRecord> GetSeckillRecord(int id)
        {
            var record = _seckillRecordService.GetSeckillRecordById(id);
            if (record == null)
            {
                return NotFound();
            }
            return record;
        }

        // POST api/<SeckillRecordController>
        [HttpPost]
        public ActionResult<SeckillRecord> PostSeckillRecord(SeckillRecord seckillRecord)
        {
            _seckillRecordService.Create(seckillRecord);
            return CreatedAtAction("GetSeckillRecord", new { id = seckillRecord.Id }, seckillRecord);
        }

        // PUT api/<SeckillRecordController>/5
        [HttpPut("{id}")]
        public IActionResult PutSeckillRecord(int id, SeckillRecord seckillRecord)
        {
            if (id != seckillRecord.Id)
            {
                return BadRequest();
            }
            try
            {
                _seckillRecordService.Update(seckillRecord);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeckillRecordExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // DELETE api/<SeckillRecordController>/5
        [HttpDelete("{id}")]
        public ActionResult<SeckillRecord> DeleteSeckillRecord(int id)
        {
            var SeckillRecord = _seckillRecordService.GetSeckillRecordById(id);
            if (SeckillRecord == null)
            {
                return NotFound();
            }
            _seckillRecordService.Delete(SeckillRecord);
            return SeckillRecord;
        }
        private bool SeckillRecordExists(int id)
        {
            return _seckillRecordService.SeckillRecordExists(id);
        }
    }
}
