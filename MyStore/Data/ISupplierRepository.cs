using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface ISupplierRepository
    {
        Supplier AddSupplier(Supplier newSupplier);
        bool Exists(int id);
        bool Delete(Supplier supplierToDelete);
        IEnumerable<Supplier> GetAll();
        Supplier GetById(int id);
        Supplier Update(Supplier supplierToUpdate);
    }
}
