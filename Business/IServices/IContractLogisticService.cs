using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IServices
{
    public interface IContractLogisticService
    {
        ContractLogisticRate AddContractLogisticRate(ContractLogisticRate ContractLogisticRate);
        ContractLogisticRate UpdateContractLogisticRate(ContractLogisticRate ContractLogisticRate);
        ContractLogisticRate GetContractLogisticRateById(Guid id);
        bool DeleteContractLogisticRate(Guid id);
        IQueryable<ContractLogisticRate> GetAllContractLogisticRates();
    }
}
