using ProductMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroService.Services
{
   public interface IProductImageService
    {
        void Create(ProductImage productImage);
        void Update(ProductImage productImage);
        void Delete(ProductImage productImage);
        bool ProductImageExists(int Id);
        IEnumerable<ProductImage> GetProducts();
        IEnumerable<ProductImage> GetProductImages(ProductImage productImage);
        ProductImage GetProductImageById(int Id);
    }
}
