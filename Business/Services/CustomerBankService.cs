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
    public class CustomerBankService : ICustomerBankService
    {
        private readonly IRepository<Bank> repository;
        private readonly IUnitofWork unitofWork;
        private readonly DataContext dataContext;
        public CustomerBankService(IRepository<Bank> _repository, IUnitofWork _unitofWork, DataContext dataContext)
        {
            repository = _repository;
            unitofWork = _unitofWork;
            this.dataContext = dataContext;
        }
        public Bank AddBank(Bank Bank)
        {
            Bank result = repository.Add(Bank);
            unitofWork.saveChanges();
            return result;
        }

        public bool DeleteBank(Guid id)
        {
            bool temp = repository.Delete(id);
            unitofWork.saveChanges();
            return temp;
        }

        public IQueryable<Bank> GetAllBanks()
        {
            IQueryable<Bank> customers = repository.GetAll();
            return customers;
        }

        public Bank GetBankById(Guid id)
        {
            return repository.GetById(id);
        }

        public Bank UpdateBank(Bank Bank)
        {
            Bank result = repository.Update(Bank);
            unitofWork.saveChanges();
            return result;
        }
    }
}
