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
    public class ExchangeRateService:IExchangeRateService
    {
        private readonly IRepository<ExchangeRate> repository;
        private readonly IUnitofWork unitofWork;
        public ExchangeRateService(IRepository<ExchangeRate> _repository, IUnitofWork _unitofWork)
        {
            repository = _repository;
            unitofWork = _unitofWork;
        }

        public ExchangeRate AddExchangeRate(ExchangeRate ExchangeRate)
        {
            ExchangeRate result = repository.Add(ExchangeRate);
            unitofWork.saveChanges();
            return result;
        }

        public ExchangeRate UpdateExchangeRate(ExchangeRate ExchangeRate)
        {
            ExchangeRate result = repository.Update(ExchangeRate);
            unitofWork.saveChanges();
            return result;
        }

        public ExchangeRate GetExchangeRateById(Guid id)
        {
            return repository.GetById(id);
        }

        public IQueryable<ExchangeRate> GetAllExchangeRates()
        {
            IQueryable<ExchangeRate> ExchangeRates = repository.GetAll();
            return ExchangeRates;
        }

        bool IExchangeRateService.DeleteExchangeRate(Guid id)
        {
            return repository.Delete(id);
        }
    }
}
