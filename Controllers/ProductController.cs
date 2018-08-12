using System;
using System.Collections.Generic;
using DutchTreat.Data.Entities;
using DutchTreat.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DutchTreat.Controllers
{
    [Route("api/[Controller]/[action]")]
    public class ProductController : Controller
    {
      private readonly  IRepository<Product> _contextRepo;
      private readonly ILogger<ProductController> _logger;
      
        public ProductController(IRepository<Product> contextRepo, ILogger<ProductController> logger)
        {
            _contextRepo = contextRepo;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(){
            try
            {
                return Ok(_contextRepo.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Api for get all products failed {ex}");
                return BadRequest("The system couldn't retrieve the required product");
            }
            
        }
    }
}