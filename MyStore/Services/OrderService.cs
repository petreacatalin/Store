using AutoMapper;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Infrastructure;
using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface IOrderService
    {
        OrderModel UpdateOrder(OrderModel model);
        Order GetById(int id);
        IEnumerable<OrderModel> GetAllOrders();
        bool Exists(int id);
        bool Delete(int id);
        OrderModel AddOrder(OrderModel newOrder);

        //IEnumerable<Order> GetAll(string? city, List<string>? country, Shippers shippers);
        
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }

        //public IEnumerable<Order> GetAll(string? city, List<string>? country, Shippers shippers)
        //{
        //    var allOrders = orderRepository.GetAll(city, country, shippers).ToList();

        //    return allOrders;
        //}

        public OrderModel AddOrder(OrderModel newOrder)
        {
            //repo...<Aadd
            Order orderToAdd = mapper.Map<Order>(newOrder);
            var addedOrder = orderRepository.Add(orderToAdd);
            newOrder = mapper.Map<OrderModel>(addedOrder);
            return newOrder;
        }

        public OrderModel UpdateOrder(OrderModel model)
        {
            Order orderToUpdate = mapper.Map<Order>(model);
            var updated = orderRepository.Update(orderToUpdate);
            return mapper.Map<OrderModel>(updated);
        }

        public Order GetById(int id)
        {
            return orderRepository.GetById(id);
        }

        public IEnumerable<OrderModel> GetAllOrders()
        {
            var allOrders = orderRepository.GetAll().ToList();
            var orderModels = mapper.Map<IEnumerable<OrderModel>>(allOrders);
            return orderModels;
        }

        public bool Exists(int id)
        {
            return orderRepository.Exists(id);
        }

        public bool Delete(int id)
        {
            var itemToDelete = orderRepository.GetById(id);
            return orderRepository.Delete(itemToDelete);
        }
    }
}
