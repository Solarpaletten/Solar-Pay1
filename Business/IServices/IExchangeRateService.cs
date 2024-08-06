using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IServices
{
    public interface IExchangeRateService
    {
        ExchangeRate AddExchangeRate(ExchangeRate ExchangeRate);
        ExchangeRate UpdateExchangeRate(ExchangeRate ExchangeRate);
        ExchangeRate GetExchangeRateById(Guid id);
        bool DeleteExchangeRate(Guid id);
        IQueryable<ExchangeRate> GetAllExchangeRates();
    }
}
