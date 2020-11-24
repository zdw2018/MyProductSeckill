using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SeckillMicroService.Context;
using SeckillMicroService.Repositories;
using SeckillMicroService.Services;
using SeckillRecordMicroService.Repositories;

namespace SeckillMicroService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //1 IOC◊¢»ÎDbcontext
            services.AddDbContext<SeckillContext>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            //2.◊¢≤·√Î…±service
            services.AddScoped<ISeckillService, SeckillService>();
            services.AddScoped<ISeckillTimeModelService, SeckillTimeModelService>();
            services.AddScoped<ISeckillRecordService, SeckillRecordService>();
            //2.◊¢≤·√Î…±≤÷¥¢
            services.AddScoped<ISeckillRepository, SeckillRepository>();
            services.AddScoped<ISeckillRecordRecordRespository, SeckillRecordRespository>();
            services.AddScoped<ISeckillTimeModelRespository, SeckillTimeModelRespository>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
