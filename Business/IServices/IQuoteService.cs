using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IServices
{
    public interface IQuoteService
    {
        Quote AddQuote(Quote Quote);
        Quote UpdateQuote(Quote Quote);
        Quote GetQuoteById(Guid id);
        bool DeleteQuote(Guid id);
        IQueryable<Quote> GetAllQuotes();
    }
}
