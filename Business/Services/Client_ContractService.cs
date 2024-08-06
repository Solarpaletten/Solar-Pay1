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
    public class Client_ContractService:IClient_ContractService
    {
        private readonly IRepository<Client_Contract> repository;
        private readonly IUnitofWork unitofWork;
        public Client_ContractService(IRepository<Client_Contract> _repository, IUnitofWork _unitofWork)
        {
            repository = _repository;
            unitofWork = _unitofWork;
        }

        public Client_Contract AddClient_Contract(Client_Contract Client_Contract)
        {
            Client_Contract result = repository.Add(Client_Contract);
            unitofWork.saveChanges();
            return result;
        }

        public Client_Contract UpdateClient_Contract(Client_Contract Client_Contract)
        {
            Client_Contract result = repository.Update(Client_Contract);
            unitofWork.saveChanges();
            return result;
        }

        public Client_Contract GetClient_ContractById(Guid id)
        {
            return repository.GetById(id);
        }

        public IQueryable<Client_Contract> GetAllClient_Contracts()
        {
            IQueryable<Client_Contract> Client_Contracts = repository.GetAll();
            return Client_Contracts;
        }
        bool IClient_ContractService.DeleteClient_Contract(Guid id)
        {
            return repository.Delete(id);
        }
    }
}
