using Business.IServices;
using Data.Context;
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
    public class CustomerAddressService : ICustomerAddressService
    {
        private readonly IRepository<Address> repository;
        private readonly IUnitofWork unitofWork;
        private readonly DataContext dataContext;
        public CustomerAddressService(IRepository<Address> _repository, IUnitofWork _unitofWork, DataContext dataContext)
        {
            repository = _repository;
            unitofWork = _unitofWork;
            this.dataContext = dataContext;
        }
        public Address AddAddress(Address Address)
        {
            Address result = repository.Add(Address);
            unitofWork.saveChanges();
            return result;
        }

        public bool DeleteAddress(Guid id)
        {
            bool temp = repository.Delete(id);
            unitofWork.saveChanges();
            return temp;
        }

        public Address GetAddressById(Guid id)
        {
            return repository.GetById(id);
        }

        public IQueryable<Address> GetAllAddresss()
        {
            IQueryable<Address> customers = repository.GetAll();
            return customers;
        }

        public Address UpdateAddress(Address Address)
        {
            Address result = repository.Update(Address);
            unitofWork.saveChanges();
            return result;
        }
    }
}
