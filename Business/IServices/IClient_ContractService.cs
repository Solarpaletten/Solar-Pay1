using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IServices
{
    public interface IClient_ContractService
    {
        Client_Contract AddClient_Contract(Client_Contract Client_Contract);
        Client_Contract UpdateClient_Contract(Client_Contract Client_Contract);
        Client_Contract GetClient_ContractById(Guid id);
        bool DeleteClient_Contract(Guid id);
        IQueryable<Client_Contract> GetAllClient_Contracts();
    }
}
