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
    public class QuoteService:IQuoteService
    {
        private readonly IRepository<Quote> repository;
        private readonly IUnitofWork unitofWork;
        public QuoteService(IRepository<Quote> _repository, IUnitofWork _unitofWork)
        {
            repository = _repository;
            unitofWork = _unitofWork;
        }

        public Quote AddQuote(Quote Quote)
        {
            Quote result = repository.Add(Quote);
            unitofWork.saveChanges();
            return result;
        }

        public Quote UpdateQuote(Quote Quote)
        {
            Quote result = repository.Update(Quote);
            unitofWork.saveChanges();
            return result;
        }

        public Quote GetQuoteById(Guid id)
        {
            return repository.GetById(id);
        }

        public IQueryable<Quote> GetAllQuotes()
        {
            IQueryable<Quote> Quotes = repository.GetAll();
            return Quotes;
        }

        bool IQuoteService.DeleteQuote(Guid id)
        {
            return repository.Delete(id);
        }
    }
}
