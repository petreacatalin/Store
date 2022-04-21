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
    public interface ISupplierService
    {
        SupplierModel AddSupplier(SupplierModel newSupplier);
        IEnumerable<SupplierModel> GetAllSuppliers();
        Supplier GetById(int id);
        SupplierModel UpdateSupplier(SupplierModel model);
        bool Delete(int id);
        bool Exists(int id);
    }


    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;
        private readonly IMapper mapper;

        public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
        {
            this.supplierRepository = supplierRepository;
            this.mapper = mapper;
        }
        public SupplierModel AddSupplier(SupplierModel newSupplier)
        {
            Supplier supplierToAdd = mapper.Map<Supplier>(newSupplier);
            var addedSupplier = supplierRepository.AddSupplier(supplierToAdd);

            newSupplier = mapper.Map<SupplierModel>(addedSupplier);
            return newSupplier;
        }

        public bool Delete(int id)
        {
            var itemToDelete = supplierRepository.GetById(id);

            return supplierRepository.Delete(itemToDelete);

        }

        public bool Exists(int id)
        {
            return supplierRepository.Exists(id);
        }

        public IEnumerable<SupplierModel> GetAllSuppliers()
        {
            var allSuppliers = supplierRepository.GetAll().ToList();

            var supplierModels = mapper.Map<IEnumerable<SupplierModel>>(allSuppliers);

            return supplierModels;
        }

        public Supplier GetById(int id)
        {
            return supplierRepository.GetById(id);
        }

        public SupplierModel UpdateSupplier(SupplierModel model)
        {
            Supplier supplierToUpdate = mapper.Map<Supplier>(model);
            var updated = supplierRepository.Update(supplierToUpdate);
            return mapper.Map<SupplierModel>(updated);
        }
    }
}
