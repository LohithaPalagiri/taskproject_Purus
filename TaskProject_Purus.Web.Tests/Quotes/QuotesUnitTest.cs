using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskProject_Purus.Web.Controllers.AdminSection;
using TaskProject_Purus.Web.Models;
using System.Linq;

namespace TaskProject_Purus.Web.Tests.Quotes
{
    [TestClass]
    public class QuotesUnitTest
    {
        [TestMethod]
        public void CreateQuoteTest()
        {
            var adminQueries = new AdminsectionQuerires();

            QuoteViewModel quote = new QuoteViewModel()
            {
                Title = "QuoteTitle",
                Description = "QuoteDescription"
            };

            var quoteId = adminQueries.CreateQuote(quote);
            var quotes = adminQueries.GetAllQuotes().ToList();

            Assert.IsTrue(quotes.Any(x => x.QuoteID == quoteId));
        }
    }
}
