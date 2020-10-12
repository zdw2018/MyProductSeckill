using Microsoft.EntityFrameworkCore;
using OrderMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMicroService.Context
{
    public class OrderDbcontext:DbContext
    {
        public OrderDbcontext(DbContextOptions<OrderDbcontext> options):base(options)
        {

        }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
    }
}
