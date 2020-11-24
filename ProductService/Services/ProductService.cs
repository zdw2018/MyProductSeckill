using ProductMicroService.Models;
using ProductMicroService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroService.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRespository _productRespository;
        public ProductService(IProductRespository productRespository)
        {
            this._productRespository = productRespository;
        }
        public void Create(Product product)
        {
            _productRespository.Create(product);
        }

        public void Delete(Product product)
        {
            _productRespository.Delete(product);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productRespository.GetProducts();
        }

        public Product ProductById(int Id)
        {
            return _productRespository.ProductById(Id);
        }

        public bool ProductExists(int Id)
        {
            return _productRespository.ProductExists(Id);
        }

        public void Update(Product product)
        {
             _productRespository.Update(product);
        }
    }
}
