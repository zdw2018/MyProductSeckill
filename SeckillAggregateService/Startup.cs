using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CommonCoreService.Filters;
using CommonCoreService.Exceptions.Handlers;
using CommonCoreService.Users;
using Newtonsoft.Json.Serialization;

namespace SeckillAggregateService
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
            services.AddControllers(options =>
            {

                options.Filters.Add<FrontResultWapper>();//通用结果
                options.Filters.Add<BizExceptionHandler>();//通用异常
                options.ModelBinderProviders.Add(new SysUserModelBinderProvider());

            }).AddNewtonsoftJson(options =>
            {
                // 防止将大写转换成小写
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });
            services.AddCors(option =>
            {
                option.AddPolicy("AllowSpecificOrigin", builder => builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("AllowSpecificOrigin");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
