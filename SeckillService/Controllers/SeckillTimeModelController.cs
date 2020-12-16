using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeckillMicroService.Models;
using SeckillMicroService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SeckillMicroService.Controllers
{
    [Route("SeckillTimeModels")]
    [ApiController]
    public class SeckillTimeModelController : ControllerBase
    {
        private readonly ISeckillService _seckillService;
        private readonly ISeckillTimeModelService _seckillTimeModelService;

        public SeckillTimeModelController(ISeckillService seckillService, ISeckillTimeModelService seckillTimeModelService)
        {
            this._seckillService = seckillService;
            this._seckillTimeModelService = seckillTimeModelService;
        }

        // GET: api/<SeckillTimeModelController>
        [HttpGet]
        public ActionResult<IEnumerable<SeckillTimeModel>> GetSeckillTimeModels()
        {
            return _seckillTimeModelService.GetSeckillTimeModels().ToList();
        }

        // GET api/<SeckillTimeModelController>/5
        [HttpGet("{id}")]
        public ActionResult<SeckillTimeModel> GetSeckillTimeModel(int id)
        {
            var seckillTimeModel = _seckillTimeModelService.GetSeckillTimeModelById(id);
            if (seckillTimeModel == null)
            {
                return NotFound();
            }
            return seckillTimeModel;
        }
        /// <summary>
        /// 根据时间编号秒杀
        /// </summary>
        /// <param name="timeId"></param>
        /// <returns></returns>
        [HttpGet("{timeId}/Seckills")]
        public ActionResult<IEnumerable<Seckill>> GetSeckills(int timeId)
        {
            Seckill seckill = new Seckill { TimeId = timeId };
            var seckills = _seckillService.GetSeckills(seckill).ToList();
            return seckills;
        }

        // POST api/<SeckillTimeModelController>
        [HttpPost]
        public ActionResult<SeckillTimeModel> PostSeckillTimeModel(SeckillTimeModel seckillTimeModel)
        {
            _seckillTimeModelService.Create(seckillTimeModel);
            return CreatedAtAction("GetSeckillTimeModel", new { id = seckillTimeModel.Id }, seckillTimeModel);

        }

        // PUT api/<SeckillTimeModelController>/5
        [HttpPut("{id}")]
        public IActionResult PutSeckillTimeModel(int id, SeckillTimeModel seckillTimeModel)
        {
            if (id != seckillTimeModel.Id)
            {
                return BadRequest();
            }
            try
            {
                _seckillTimeModelService.Update(seckillTimeModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExistsSeckillTimeModel(id))
                {
                    return NotFound();
                }
                throw;
            }
            return NoContent();
        }

        // DELETE api/<SeckillTimeModelController>/5
        [HttpDelete("{id}")]
        public ActionResult<SeckillTimeModel> DeleteSeckillTimeModel(int id)
        {
            var seckillTimeModel = _seckillTimeModelService.GetSeckillTimeModelById(id);
            if (seckillTimeModel == null)
            {
                return NotFound();
            }
            _seckillTimeModelService.Delete(seckillTimeModel);
            return seckillTimeModel;
        }
        private bool ExistsSeckillTimeModel(int Id)
        {
            return _seckillTimeModelService.SeckillTimeModelExists(Id);
        }
    }
}
