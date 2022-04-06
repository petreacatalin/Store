using MyStore.Domain.Entities;
using MyStore.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace MyStore.Data
{
    public interface IOrderRepository
    {
        Order Add(Order newOrder);
        bool Delete(Order orderToDelete);
        bool Exists(int id);
        IEnumerable<Order> GetAll();
        Order GetById(int id);
        Order Update(Order orderToUpdate);
        //IQueryable<Order> GetAll(string? city, List<string>? country, Shippers shippers);
    }
}