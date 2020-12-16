using CommonCoreService.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeckillMicroService.Models;
using SeckillMicroService.Pos;
using SeckillMicroService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SeckillMicroService.Controllers
{
    /// <summary>
    /// 秒杀服务控制器
    /// </summary>
    [Route("Seckills")]
    [ApiController]
    public class SeckillsController : ControllerBase
    {
        private readonly ISeckillService _seckillService;
        public SeckillsController(ISeckillService seckillService)
        {
            this._seckillService = seckillService;
        }
        // GET: api/<SeckillsController>
        [HttpGet]
        public ActionResult<IEnumerable<Seckill>> GetSeckills()
        {
            return _seckillService.GetSeckills().ToList();
        }

        // GET api/<SeckillsController>/5
        [HttpGet("{id}")]
        public ActionResult<Seckill> GetSeckill(int id)
        {
            var seckill = _seckillService.GetSeckillById(id);
            if (seckill == null)
            {
                return NotFound();
            }
            return seckill;
        }
        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="seckill"></param>
        /// <returns></returns>
        [HttpGet("GetList")]
        public ActionResult<IEnumerable<Seckill>> GetList([FromQuery] Seckill seckill)
        {
            return _seckillService.GetSeckills(seckill).ToList();
        }

        // POST api/<SeckillsController>
        [HttpPost]
        public ActionResult<Seckill> PostSeckill(Seckill seckill)
        {
            _seckillService.Create(seckill);
            return CreatedAtAction("GetSeckill", new { id = seckill.Id }, seckill);
        }

        // PUT api/<SeckillsController>/5
        [HttpPut("{id}")]
        public IActionResult PutSeckill(int id, Seckill seckill)
        {
            if (id != seckill.Id)
            {
                return BadRequest();
            }
            try
            {
                _seckillService.Update(seckill);
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!SeckillExists(id))
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
        [NonAction]
        public IActionResult SetProductStock(SeckillPo seckillPo)
        {
            //1.查询秒杀库存
            Seckill seckill = _seckillService.GetSeckillByProductId(seckillPo.ProductId);
            //2.判断秒杀库存是否完成
            if (seckill.SeckillStock <= 0)
            {
                throw new BizException("秒杀库存完了");
            }
            if (seckill.SeckillStock <= seckillPo.ProductCount)
            {
                throw new BizException($"秒杀库存不足{seckillPo.ProductCount}个");
            }
            //3.扣减库存
            seckill.SeckillStock -= seckillPo.ProductCount;
            //4.更新秒杀库存
            _seckillService.Update(seckill);
            return Ok("更新库存成功");
        }
        // DELETE api/<SeckillsController>/5
        [HttpDelete("{id}")]
        public ActionResult<Seckill> DeleteSeckill(int id)
        {
            var seckill = _seckillService.GetSeckillById(id);
            if (seckill == null)
            {
                return NotFound();
            }
            _seckillService.Delete(seckill);
            return seckill;
        }
        private bool SeckillExists(int id)
        {
            return _seckillService.SeckillExists(id);
        }
    }
}
