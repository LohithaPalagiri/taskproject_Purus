using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject_Purus.Entity.QuoteRepository;
namespace TaskProject_Purus.Entity.QuoteRepository
{
   public class QuoteRepository:IQuoteRepository
    {
        private Customercontext context;
        public QuoteRepository(Customercontext context)
        {
            this.context = context;
        }
        public Quote GetQuoteById(int id)
        {
            return context.Quotes.Find(id);
        }
       public IQueryable<Quote> GetQuotes()
        {
           return  context.Quotes;
        }
        public int InsertQuoteAndGetId(Quote quote)
        {
            context.Quotes.Add(quote);
            context.SaveChanges();
            return quote.QuoteID;
        }
        public void UpdateQuote(Quote quote)
        {

            context.Entry(quote).State = System.Data.EntityState.Modified;
        }
        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
