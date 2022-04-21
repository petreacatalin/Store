using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly StoreContext context;

        public CustomerRepository(StoreContext context)
        {
            this.context = context;
        }
        public IEnumerable<Customer> GetAll()
        {
            return context.Customers.ToList();
        }

        public Customer Add(Customer newCustomer)
        {
            var addedCustomer = context.Customers.Add(newCustomer);
            context.SaveChanges();
            return addedCustomer.Entity;
        }

        public bool Delete(Customer customerToDelete)
        {
            var deletedItem = context.Customers.Remove(customerToDelete);
            context.SaveChanges();
            return deletedItem != null;

        }

        public bool Exists(int id)
        {
            var exists = context.Customers.Count(x => x.Custid == id);
            return exists == 1;
        }               

        public Customer GetById(int id)
        {
            return context.Customers.FirstOrDefault(x => x.Custid == id);

        }

        public Customer Update(Customer customerToUpdate)
        {
            var entity = context.Customers.Update(customerToUpdate);
            context.SaveChanges();
            return entity.Entity;
        }
    }
}
