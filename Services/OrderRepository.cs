using System.Collections.Generic;
using System.Linq;
using DutchTreat.Data;
using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DutchTreat.Services
{
    
    public class OrderRepository : IRepository<Order>
    {

       
        private readonly ILogger<OrderRepository> _logger;
        private readonly DutchContext _context;
        public OrderRepository(DutchContext context,  ILogger<OrderRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.Include(o => o.Items).ToList();
        }

        public IEnumerable<Order> GetProductByCategory(string category)
        {
            throw new System.NotImplementedException();
        }

        public bool saveAll()
        {
            throw new System.NotImplementedException();
        }
    }
}