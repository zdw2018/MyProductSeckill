using ProductMicroService.Context;
using ProductMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ProductMicroService.Repositories
{
    public class ProductImageRespository : IProductImageRespository
    {
        private readonly ProductContext _productContext;
        public ProductImageRespository(ProductContext productContext)
        {
            this._productContext = productContext;
        }
        public void Create(ProductImage productImage)
        {
            _productContext.Set<ProductImage>().Add(productImage);
            _productContext.SaveChanges();
        }

        public void Delete(ProductImage productImage)
        {
            _productContext.Set<ProductImage>().Remove(productImage);
            _productContext.SaveChanges();
        }

        public ProductImage GetProductImageById(int Id)
        {
           return _productContext.Set<ProductImage>().Find(Id);
         
        }
        //根据产品ID查找图片
        public IEnumerable<ProductImage> GetProductImages(ProductImage productImage)
        {
            return _productContext.Set<ProductImage>().Where(x => x.ProductId == productImage.ProductId);
        }

        public IEnumerable<ProductImage> GetProducts()
        {
            return _productContext.Set<ProductImage>().ToList();
        }

        public bool ProductImageExists(int Id)
        {
            return _productContext.Set<ProductImage>().Any(x=>x.Id== Id);
        }

        public void Update(ProductImage productImage)
        {
            _productContext.Set<ProductImage>().Update(productImage);
            _productContext.SaveChanges();
        }
    }
}
