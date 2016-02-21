using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskProject_Purus.Entity.CustomerRepository;
using TaskProject_Purus.Entity;
using System.Linq;

namespace TaskProject_Purus.Web.Tests.Customers
{
    [TestClass]
    public class CustomerRequestUnitTest
    {
        private CustomerRepository _customerRepository = new CustomerRepository(new Customercontext());
        [TestMethod]
        public void TestQuoteStatusAndQuotesIds()
        {
            var customers = _customerRepository.GetCustomers().ToList();
            Assert.IsFalse(customers.Any(x => x.Status != null && x.Status.Value == true && x.QuoteID == null));
        }
    }
}
