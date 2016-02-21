using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskProject_Purus.Entity;
using TaskProject_Purus.Web.Models;
namespace TaskProject_Purus.Web.Controllers.Queries
{
    public static class QuoteQueries
    {
        public static Quote CreateQuoteFromQuoteViewModel(QuoteViewModel model)
        {
            Quote quote = new Quote();
            quote.QuoteTtile = model.Title;
            quote.QuoteDescription = model.Description;
            return quote;
           
        }
    }
}