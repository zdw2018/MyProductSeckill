using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SeckillMicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeckillMicroService.Context
{
    public class SeckillContext:DbContext
    {
        public SeckillContext(DbContextOptions<SeckillContext> options):base(options)
        {

        }
        public DbSet<Seckill> Seckills { get; set; }
        public DbSet<SeckillRecord> SeckillRecords { get; set; }
        public DbSet<SeckillTimeModel> SeckillTimeModels { get; set; }
    }
}
