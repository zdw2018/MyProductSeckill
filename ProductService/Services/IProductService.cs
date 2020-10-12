using ProductMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroService.Services
{
    public interface IProductService
    {
        void Create(Product product);
        void Delete(Product product);
        void Update(Product product);
        bool ProductExists(int Id);
        IEnumerable<Product> GetProducts();
        Product ProductById(int Id);
    }
}
