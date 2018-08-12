using System.Collections.Generic;
using DutchTreat.Data.Entities;

namespace DutchTreat.Services
{
    public interface IRepository<T>
    {
           IEnumerable<T> GetAll();

          IEnumerable<T> GetProductByCategory (string category);

          bool saveAll();
    }
}