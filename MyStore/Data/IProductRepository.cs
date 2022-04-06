using MyStore.Domain.Entities;
using System.Collections.Generic;

namespace MyStore.Data
{
    public interface IProductRepository
    {
        Product Add(Product newProduct);
        bool Delete(Product productToDelete);
        bool Exists(int id);

        ///data access code
        ///CRUD
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        Product Update(Product productToUpdate);
    }
}
