using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface ICustomerRepository
    {
        Customer Add(Customer newCustomer);
        bool Delete(Customer customerToDelete);
        bool Exists(int id);
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        Customer Update(Customer customerToUpdate);
    }
}
