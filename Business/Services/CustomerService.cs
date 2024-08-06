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
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> repository;
        private readonly IUnitofWork unitofWork;
        private readonly DataContext dataContext;
        public CustomerService(IRepository<Customer> _repository, IUnitofWork _unitofWork, DataContext dataContext)
        {
            repository = _repository;
            unitofWork = _unitofWork;
            this.dataContext = dataContext;
        }

        public Customer AddCustomer(Customer Customer)
        {
            Customer result = repository.Add(Customer);
            unitofWork.saveChanges();
            return result;
        }

        public bool DeleteCustomer(Guid id)
        {
            bool temp = repository.Delete(id);
            unitofWork.saveChanges();
            return temp;
        }

        public IQueryable<Customer> GetAllCustomers()
        {
            IQueryable<Customer> customers = repository.GetAll();
            return customers;
        }

        public Customer GetCustomerById(Guid id)
        {
            return repository.GetById(id);
        }

        public Customer UpdateCustomer(Customer Customer)
        {
            Customer result = repository.Update(Customer);
            unitofWork.saveChanges();
            return result;
        }
    }
}
