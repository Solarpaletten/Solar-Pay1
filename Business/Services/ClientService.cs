using Business.IServices;
using Data.Context;
using Data.DTOs;
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
    public class ClientService:IClientService
    {
        private readonly IRepository<Client> repository;
        private readonly IRepository<Client_Contract> ccRepo;
        private readonly IUnitofWork unitofWork;
        private readonly DataContext dataContext;
        public ClientService(IRepository<Client> _repository,IRepository<Client_Contract> ccRepo, IUnitofWork _unitofWork,DataContext dataContext)
        {
            repository = _repository;
            unitofWork = _unitofWork;
            this.ccRepo = ccRepo;
            this.dataContext = dataContext;
        }

        public Client AddClient(Client Client)
        {
            Client result = repository.Add(Client);
            Client_Contract contract = new Client_Contract() { 
            Attachment=Client.Attachment,
            ContractStartDate=Client.StartDate,
            ContractEndDate=Client.EndDate,
            ClientId=result.Id,
            ContractId=Guid.Parse(Client.ContractId)
            };
            ccRepo.Add(contract);
            unitofWork.saveChanges();
            return result;
        }

        public Client UpdateClient(Client Client)
        {
            Client result = repository.Update(Client);
            unitofWork.saveChanges();
            return result;
        }

        public Client GetClientById(Guid id)
        {
            return repository.GetById(id);
        }

        public IQueryable<Client> GetAllClients()
        {
            IQueryable<Client> Clients = repository.GetAll();
            return Clients;
        }

        bool IClientService.DeleteClient(Guid id)
        {
            return repository.Delete(id);
        }

        //public List<ClientContractsDTO> GetClientContractsById(Guid Id)
        //{
        //        List<ClientContractsDTO> contraccts = (from con in dataContext.Contracts
        //                                               join cc in dataContext.Client_Contract on con.Id equals cc.ContractId
        //                                               join cli in dataContext.Clients on cc.ClientId equals cli.Id
        //                                               where cli.Id == Id
        //                                               select new ClientContractsDTO
        //                                               {
        //                                                   ContractId = con.Id.ToString(),
        //                                                   ClientId = Id.ToString(),
        //                                                   ClientName = cc.Client.FirstName + " " + cc.Client.LastName,
        //                                                   Attachment = cc.Attachment,
        //                                                   StartDate = cc.ContractStartDate,
        //                                                   EndDate = cc.ContractEndDate,
        //                                                   ContractName = con.Name,
        //                                                   ContractFullForm = con.Fullform
        //                                               }).ToList();
        //        return contraccts;
        //}
    }
}
