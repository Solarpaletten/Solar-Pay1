using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IServices
{
    public interface ICustomerBankService
    {
        Bank AddBank(Bank Bank);
        Bank UpdateBank(Bank Bank);
        Bank GetBankById(Guid id);
        bool DeleteBank(Guid id);
        IQueryable<Bank> GetAllBanks();
    }
}
