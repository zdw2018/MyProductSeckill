using Microsoft.EntityFrameworkCore;
using PaymentMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentMicroService.Context
{
    public class PaymentContext:DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options):base(options)
        {

        }
       public DbSet<Payment> Payment { get; set; }
    }
}
