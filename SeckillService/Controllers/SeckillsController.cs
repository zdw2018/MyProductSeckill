using Microsoft.AspNetCore.Mvc;
using SeckillMicroService.Models;
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
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SeckillsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
