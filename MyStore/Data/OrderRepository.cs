﻿using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Entities;
using MyStore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreContext context;

        public OrderRepository(StoreContext context)
        {
            this.context = context;
        }

        //add filters
        //public IQueryable<Order> GetAll(string? city, List<string>? country, Shippers shippers)
        //{
        //    var query = this.context.Orders
        //        .Include(x => x.OrderDetails)
        //        .Select(x => x);

        //    if (!string.IsNullOrEmpty(city))
        //    {
        //        query = query.Where(x => x.Shipcity == city);
        //    }


        //    query = query.Where(x => x.Shipperid == (int)shippers);

        //    if (country.Any())
        //    {
        //        query = query.Where(x => country.Contains(x.Shipcountry));
        //    }

        //    //var pageNumber = 3;
        //    //var itemsPerPage = 20;
        //    //query = query.Skip(pageNumber - 1 * itemsPerPage).Take(itemsPerPage);

        //    return query;
        //}

       

        public Order Add(Order newOrder)
        {
            var addedOrder = context.Orders.Add(newOrder);
            context.SaveChanges();
            return addedOrder.Entity;
        }

        public bool Delete(Order orderToDelete)
        {
            var deletedItem = context.Orders.Remove(orderToDelete);
            context.SaveChanges();
            return deletedItem != null;
        }

        public bool Exists(int id)
        {
            var exists = context.Orders.Count(o => o.Orderid == id);
            return exists == 1;
        }

        public IEnumerable<Order> GetAll()
        {
            return context.Orders.ToList();
        }

        public Order GetById(int id)
        {
            return context.Orders.FirstOrDefault(o => o.Orderid == id);
        }

        public Order Update(Order orderToUpdate)
        {
            var entity = context.Orders.Update(orderToUpdate);
            context.SaveChanges();
            return entity.Entity;
        }
    }
}
