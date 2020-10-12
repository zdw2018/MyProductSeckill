using Microsoft.EntityFrameworkCore;
using ProductMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroService.Context
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
    }
}
