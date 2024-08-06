using Business.IServices;
using Data.Entities;
using DataAccess.Repository;
using DataAccess.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class SupplierService:ISupplierService
    {
        private readonly IRepository<Supplier> repository;
        private readonly IUnitofWork unitofWork;
        public SupplierService(IRepository<Supplier> _repository, IUnitofWork _unitofWork)
        {
            repository = _repository;
            unitofWork = _unitofWork;
        }

        public Supplier AddSupplier(Supplier Supplier)
        {
            Supplier result = repository.Add(Supplier);
            unitofWork.saveChanges();
            return result;
        }

        public Supplier UpdateSupplier(Supplier Supplier)
        {
            Supplier result = repository.Update(Supplier);
            unitofWork.saveChanges();
            return result;
        }

        public Supplier GetSupplierById(Guid id)
        {
            return repository.GetById(id);
        }

        public IQueryable<Supplier> GetAllSuppliers()
        {
            IQueryable<Supplier> Suppliers = repository.GetAll();
            return Suppliers;
        }

        bool ISupplierService.DeleteSupplier(Guid id)
        {
            return repository.Delete(id);
        }
    }
}
