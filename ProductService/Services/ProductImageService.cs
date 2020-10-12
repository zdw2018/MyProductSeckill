using ProductMicroService.Models;
using ProductMicroService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ProductMicroService.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly IProductImageRespository _productImageRespository;
        public ProductImageService(IProductImageRespository productImageRespository)
        {
            this._productImageRespository = productImageRespository;
        }
        public void Create(ProductImage productImage)
        {
            _productImageRespository.Create(productImage);
        }

        public void Delete(ProductImage productImage)
        {
            _productImageRespository.Delete(productImage);
        }

        public ProductImage GetProductImageById(int Id)
        {
            return _productImageRespository.GetProductImageById(Id);
        }

        public IEnumerable<ProductImage> GetProductImages(ProductImage productImage)
        {
            return _productImageRespository.GetProductImages(productImage);
        }

        public IEnumerable<ProductImage> GetProducts()
        {
            return _productImageRespository.GetProducts();
        }

        public bool ProductImageExists(int Id)
        {
            return _productImageRespository.ProductImageExists(Id);       
        }

        public void Update(ProductImage productImage)
        {
            _productImageRespository.Update(productImage);
        }
    }
}
