using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DutchTreat.Data
{

    // This class is used to seed a database with data from product.json file
    public class DbSeeder
    {
        private readonly DutchContext _ctx;
        private readonly IHostingEnvironment __hosting;
        public DbSeeder(DutchContext ctx, IHostingEnvironment hosting)
        {
         _ctx = ctx;
         __hosting = hosting; 
        }
        public void Seed(){
            _ctx.Database.EnsureCreated();
            var filePath = Path.Combine(__hosting.ContentRootPath, "Data/product.json");
          if(!_ctx.Products.Any()){
            var json = File.ReadAllText(filePath);
            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
            _ctx.Products.AddRange(products);

            var order = new Order(){
                OrderDate = DateTime.Now,
                OrderNumber = "2345",
                Items = new List<OrderItem>(){
                    new OrderItem(){
                        Product = products.First(),
                        Quantity = 5,
                        UnitPrice = products.First().Price
                    }
                }

            };
            _ctx.Orders.Add(order);
            _ctx.SaveChanges();
          }
        }
    }
}