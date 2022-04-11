using AutoMapper;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface ICustomerService
    {
        CustomerModel AddCustomer(CustomerModel newCustomer);
        bool Exists(int id);
        bool Delete(int id);
        IEnumerable<CustomerModel> GetAllCustomers();
        Customer GetById(int id);
        CustomerModel UpdateCostumer(CustomerModel model);

    }


    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }
        public CustomerModel AddCustomer(CustomerModel newCustomer)
        {
            Customer customerToAdd = mapper.Map<Customer>(newCustomer);
            var addedCustomer = customerRepository.Add(customerToAdd);

            newCustomer = mapper.Map<CustomerModel>(addedCustomer);
            return newCustomer;
        }

        public bool Delete(int id)
        {
            var itemToDelete = customerRepository.GetById(id);
            return customerRepository.Delete(itemToDelete);
        }

        public bool Exists(int id)
        {
            return customerRepository.Exists(id);
        }

        public IEnumerable<CustomerModel> GetAllCustomers()
        {
            var allCustomers = customerRepository.GetAll().ToList();
            var customerModels = mapper.Map<IEnumerable<CustomerModel>>(allCustomers);

            return customerModels;
        }

        public Customer GetById(int id)
        {
            return customerRepository.GetById(id);
        }

        public CustomerModel UpdateCostumer(CustomerModel model)
        {
            Customer customerToUpdate = mapper.Map<Customer>(model);
            var updated = customerRepository.Update(customerToUpdate);

            return mapper.Map<CustomerModel>(updated);
        }
    }
}
