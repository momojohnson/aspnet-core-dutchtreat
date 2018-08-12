using System;
using DutchTreat.Data;
using DutchTreat.Data.Entities;
using DutchTreat.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DutchTreat.Controllers
{
    [Route("api/[Controller]")]
    public class OrdersController : Controller
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IRepository<Order> _orderRepo;

        public OrdersController(IRepository<Order> orderRepo, ILogger<OrdersController> logger)
        {
            _logger = logger;
            _orderRepo = orderRepo;
        }
        

        [HttpGet]
        public IActionResult Get(){
            try
            {
                return Ok(_orderRepo.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Orders route url has been called");
                return BadRequest($"Could provide the information you requested {ex}");
            }
        }

    }
}