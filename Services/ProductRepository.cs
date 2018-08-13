using System;
using System.Collections.Generic;
using System.Linq;
using DutchTreat.Data;
using DutchTreat.Data.Entities;
using Microsoft.Extensions.Logging;

namespace DutchTreat.Services
{
    public class ProductRepository : IRepository<Product>
    {
       private DutchContext _context;
       private readonly ILogger<ProductRepository> _logger;
       public ProductRepository(DutchContext context, ILogger<ProductRepository> logger)
       {
           _context = context;
           _logger = logger;
       }

        public IEnumerable<Product> GetAll (){
            try
            {
                 _logger.LogInformation("Get All Products was called");
            return _context.Products
                    .OrderBy(p => p.Title);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Failed to get all product from database {ex}");
                return null;
            }
           
        }
        public IEnumerable<Product> GetProductByCategory (string category){
            try
            {
                  return _context.Products.Where(p => p.Category == category)
                    .OrderBy(p => p.Category)
                    .ToList();
            }
            catch (Exception ex)
            {
                
               _logger.LogInformation($"Failed to get product by category {ex}");
               return null;
            }
          
         }

        public bool saveAll()        
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                
               _logger.LogInformation($"Failed to save changes to database {ex}");
               return false;
            }
            
        }

        public Product GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveEntity(Product item)
        {
            throw new NotImplementedException();
        }
    }
}