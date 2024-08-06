using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IServices
{
    public interface IContractQuoteRateService
    {
        ContractQuoteRate AddContractQuoteRate(ContractQuoteRate ContractQuoteRate);
        ContractQuoteRate UpdateContractQuoteRate(ContractQuoteRate ContractQuoteRate);
        ContractQuoteRate GetContractQuoteRateById(Guid id);
        bool DeleteContractQuoteRate(Guid id);
        IQueryable<ContractQuoteRate> GetAllContractQuoteRates();
    }
}
