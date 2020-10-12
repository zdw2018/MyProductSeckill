using ProductMicroService.Context;
using ProductMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ProductMicroService.Repositories
{
    public class ProductRespository : IProductRespository
    {
        private readonly ProductContext _productContext;
        public ProductRespository(ProductContext productContext)
        {
            this._productContext = productContext;
        }
        public void Create(Product product)
        {
            _productContext.Set<Product>().Add(product);
            _productContext.SaveChanges();
        }

        public void Delete(Product product)
        {
            _productContext.Set<Product>().Remove(product);
            _productContext.SaveChanges();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productContext.Set<Product>().ToList();
        }

        public Product ProductById(int Id)
        {
            return _productContext.Set<Product>().Find(Id);
        }

        public bool ProductExists(int Id)
        {
           return _productContext.Set<Product>().Any(x=>x.Id==Id);
           
        }

        public void Update(Product product)
        {
            _productContext.Set<Product>().Update(product);
            _productContext.SaveChanges();
        }
    }
}
