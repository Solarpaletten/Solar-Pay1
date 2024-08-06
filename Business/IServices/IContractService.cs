using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IServices
{
    public interface IContractService
    {
        Contract AddContract(Contract contract);
        Contract UpdateContract(Contract contract);
        Contract GetContractById(Guid id);
        bool DeleteContract(Guid id);
        IQueryable<Contract> GetAllContracts();
        //bool UpdateUserImage(string ImageUrl, Guid id);
    }
}
