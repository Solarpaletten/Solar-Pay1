using Data.DTOs;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IServices
{
    public interface IClientService
    {
        Client AddClient(Client Client);
        Client UpdateClient(Client Client);
        Client GetClientById(Guid id);
        //List<ClientContractsDTO> GetClientContractsById(Guid id);
        bool DeleteClient(Guid id);
        IQueryable<Client> GetAllClients();
    }
}
