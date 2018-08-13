using System;
using System.Collections.Generic;
using AutoMapper;
using DutchTreat.Data;
using DutchTreat.Data.Entities;
using DutchTreat.Models;
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
        private readonly IMapper _mapper;

        public OrdersController(IRepository<Order> orderRepo, ILogger<OrdersController> logger, IMapper mapper)
        {
            _logger = logger;
            _orderRepo = orderRepo;
            _mapper = mapper;
        }
        

        [HttpGet]
        public IActionResult Get(){
            try
            {
                _logger.LogInformation("Orders route url has been called");
                return Ok(_mapper.Map<IEnumerable<Order>, IEnumerable<OrderModel>>(_orderRepo.GetAll()));
                    
            }
            catch (Exception ex)
            {
            
                return BadRequest($"Could provide the information you requested {ex}");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id){
                try
            {
                _logger.LogInformation("Called to get specific order was done");
                var order = _orderRepo.GetOrderById(id);
                if( order != null){
                    return Ok(_mapper.Map<Order, OrderModel>(order));
                }
                return NotFound();
                    
            }
            catch (Exception ex)
            {
            
                return BadRequest($"Could provide the information you requested {ex}");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]OrderModel model){
          try
          {
              if(ModelState.IsValid){
                Order newOrder = _mapper.Map<OrderModel, Order>(model);
                if(newOrder.OrderDate == DateTime.MinValue){
                    newOrder.OrderDate = DateTime.Now;
                }

             _orderRepo.SaveEntity(newOrder);
              if(_orderRepo.saveAll()){
                  OrderModel orderModel = new OrderModel(){
                      OrderId = newOrder.Id,
                      OrderNumber = newOrder.OrderNumber,
                      OrderDate = newOrder.OrderDate
                  };
                return Created($"api/orders/{newOrder.Id}", _mapper.Map<Order, OrderModel>(newOrder));
              
              }
               
              }else{
                  return BadRequest(ModelState);
              }
              
             
          }
          catch (Exception ex)
          {
              _logger.LogError($"Failed to save order to database {ex}");
              return BadRequest();
          }
        return BadRequest("Failed to save new order to database");
        }

    }
}