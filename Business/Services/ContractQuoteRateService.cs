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
    public class ContractQuoteRateService:IContractQuoteRateService
    {
        private readonly IRepository<ContractQuoteRate> repository;
        private readonly IUnitofWork unitofWork;
        public ContractQuoteRateService(IRepository<ContractQuoteRate> _repository, IUnitofWork _unitofWork)
        {
            repository = _repository;
            unitofWork = _unitofWork;
        }

        public ContractQuoteRate AddContractQuoteRate(ContractQuoteRate ContractQuoteRate)
        {
            ContractQuoteRate result = repository.Add(ContractQuoteRate);
            unitofWork.saveChanges();
            return result;
        }

        public ContractQuoteRate UpdateContractQuoteRate(ContractQuoteRate ContractQuoteRate)
        {
            ContractQuoteRate result = repository.Update(ContractQuoteRate);
            unitofWork.saveChanges();
            return result;
        }

        public ContractQuoteRate GetContractQuoteRateById(Guid id)
        {
            return repository.GetById(id);
        }

        public IQueryable<ContractQuoteRate> GetAllContractQuoteRates()
        {
            IQueryable<ContractQuoteRate> ContractQuoteRates = repository.GetAll();
            return ContractQuoteRates;
        }

        bool IContractQuoteRateService.DeleteContractQuoteRate(Guid id)
        {
            return repository.Delete(id);
        }
    }
}
