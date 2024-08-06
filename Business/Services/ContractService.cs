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
    public class ContractService : IContractService
    {

        private readonly IRepository<Contract> repository;
        private readonly IUnitofWork unitofWork;
        public ContractService(IRepository<Contract> _repository, IUnitofWork _unitofWork)
        {
            repository = _repository;
            unitofWork = _unitofWork;
        }

        public Contract AddContract(Contract contract)
        {
            Contract result = repository.Add(contract);
            unitofWork.saveChanges();
            return result;
        }

        public Contract UpdateContract(Contract contract)
        {
            Contract result = repository.Update(contract);
            unitofWork.saveChanges();
            return result;
        }

        public Contract GetContractById(Guid id)
        {
            return repository.GetById(id);
        }

        public IQueryable<Contract> GetAllContracts()
        {
            IQueryable<Contract> contracts = repository.GetAll();
            return contracts;
        }

        bool IContractService.DeleteContract(Guid id)
        {
            return repository.Delete(id);
        }

        //bool UpdateUserImage(string ImageUrl, Guid id)
        //{
        //    //UserProfile user = repository.GetById(id);
        //    ////user.ProfileImage = "https://localhost:44346/" + ImageUrl;
        //    //repository.Update(user);
        //    //unitofWork.saveChanges();
        //    return true;
        //}
    }
}
