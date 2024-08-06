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
    public class ContractLogisticService:IContractLogisticService
    {
        private readonly IRepository<ContractLogisticRate> repository;
        private readonly IUnitofWork unitofWork;
        public ContractLogisticService(IRepository<ContractLogisticRate> _repository, IUnitofWork _unitofWork)
        {
            repository = _repository;
            unitofWork = _unitofWork;
        }

        public ContractLogisticRate AddContractLogisticRate(ContractLogisticRate ContractLogisticRate)
        {
            ContractLogisticRate result = repository.Add(ContractLogisticRate);
            unitofWork.saveChanges();
            return result;
        }

        public ContractLogisticRate UpdateContractLogisticRate(ContractLogisticRate ContractLogisticRate)
        {
            ContractLogisticRate result = repository.Update(ContractLogisticRate);
            unitofWork.saveChanges();
            return result;
        }

        public ContractLogisticRate GetContractLogisticRateById(Guid id)
        {
            return repository.GetById(id);
        }

        public IQueryable<ContractLogisticRate> GetAllContractLogisticRates()
        {
            IQueryable<ContractLogisticRate> ContractLogisticRates = repository.GetAll();
            return ContractLogisticRates;
        }

        bool IContractLogisticService.DeleteContractLogisticRate(Guid id)
        {
            return repository.Delete(id);
        }
    }
}
