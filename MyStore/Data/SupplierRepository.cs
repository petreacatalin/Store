﻿using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly StoreContext context;

        public SupplierRepository(StoreContext context)
        {
            this.context = context;
        }
        public Supplier AddSupplier(Supplier newSupplier)
        {

            var addedSupplier = context.Suppliers.Add(newSupplier);
            context.SaveChanges();

            return addedSupplier.Entity;
        }

        public bool Delete(Supplier supplierToDelete)
        {
            var itemToDelete = context.Suppliers.Remove(supplierToDelete);
            context.SaveChanges();
            return itemToDelete != null;
        }

        public bool Exists(int id)
        {
            var exists = context.Suppliers.Count(x => x.Supplierid == id);
            return exists == 1;
        }

        public IEnumerable<Supplier> GetAll()
        {
            return context.Suppliers.ToList();
        }

        public Supplier GetById(int id)
        {
            return context.Suppliers.FirstOrDefault(x => x.Supplierid == id);
        }

        public Supplier Update(Supplier supplierToUpdate)
        {
            var entity = context.Suppliers.Update(supplierToUpdate);
            context.SaveChanges();
            return entity.Entity;
        }
    }
}
