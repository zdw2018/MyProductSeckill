using CommonCoreService.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductMicroService.Models;
using ProductMicroService.Pos;
using ProductMicroService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductMicroService.Controllers
{
    /// <summary>
    /// 商品服务控制器
    /// </summary>
    [Route("Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            this._productService = productService;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return _productService.GetProducts().ToList();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> GetProducts(int id)
        {
            var product = _productService.ProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        // POST api/<ProductsController>
        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            _productService.Create(product);
            return CreatedAtAction("GetProducts", new { id = product.Id }, product);
        }
        [HttpPut("{id}/set-Stock")]
        public IActionResult PutProductStock(int id, ProductPo productPo)
        {
            if (id != productPo.ProductId)
            {
                return BadRequest();
            }
            //1.查询商品
            var product = _productService.ProductById(id);

            //2.判断商品库存是否完成
            if (product.ProductStock <= 0)
            {
                throw new BizException("库存完了");
            }
            if (product.ProductStock < productPo.ProductCount)
            {
                throw new BizException("库存不足");
            }
            //3.扣减商品库存
            product.ProductStock -= productPo.ProductCount;
            //4.更新商品库存
            _productService.Update(product);
            return Ok("商品库存更新成功");
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            try
            {
                _productService.Update(product);
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!ProductExists(id))
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

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public ActionResult<Product> DeleteProduct(int id)
        {
            var product = _productService.ProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            _productService.Delete(product);
            return product;

        }
        private bool ProductExists(int id)
        {
            return _productService.ProductExists(id);
        }
        [NonAction]
        public IActionResult SetProductStock(ProductPo productPo)
        {
            //1.获取商品
            var product = _productService.ProductById(productPo.ProductId);
            //2.判断商品库存是否完成
            if (product.ProductStock <= 0)
            {
                throw new BizException("库存完了");
            }
            if (product.ProductStock < productPo.ProductCount)
            {
                throw new BizException("库存不足");
            }
            //3.扣减商品库存
            product.ProductStock -= productPo.ProductCount;
            //4.更新商品库存
            _productService.Update(product);
            return Ok("商品库存更新成功");
        }
    }
}
