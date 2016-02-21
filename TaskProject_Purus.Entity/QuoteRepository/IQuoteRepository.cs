using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject_Purus.Entity.QuoteRepository
{
    public interface IQuoteRepository : IDisposable
    {
        IQueryable<Quote> GetQuotes();
        int InsertQuoteAndGetId(Quote quote);
        void UpdateQuote(Quote quote);
        Quote GetQuoteById(int id);
        void Save();
    }
}
