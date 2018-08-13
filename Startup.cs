using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DutchTreat.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DutchTreat.Data;
using DutchTreat.Data.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using AutoMapper;

namespace DutchTreat
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DutchContext>(cfg =>{
                cfg.UseSqlServer(_config.GetConnectionString("DutchConnectString"));
            });
            services.AddAutoMapper();
            services.AddTransient<ImailService, NullMailService>();
            services.AddTransient<IRepository<Product>, ProductRepository>();
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<DbSeeder>();
            services.AddMvc()
                .AddJsonOptions(option => option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }else{
                app.UseExceptionHandler("/error");
            }
            app.UseStaticFiles();
            app.UseMvc(routes => {
                routes.MapRoute(
                    "default",
                    "/{controller}/{action}/{id?}",
                    new {controller = "App", Action="Index"});
            });
            // Seeding of the database with some dummy data
            if(env.IsDevelopment()){
                using(var scope = app.ApplicationServices.CreateScope()){
                    var seeder = scope.ServiceProvider.GetService<DbSeeder>();
                    seeder.Seed();
                }
            }
        }
    }
}
