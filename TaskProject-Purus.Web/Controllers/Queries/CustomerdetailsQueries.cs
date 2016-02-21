using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskProject_Purus.Entity.CustomerRepository;
using TaskProject_Purus.Entity;
using System.Web.Http.ModelBinding;
using TaskProject_Purus.Web.Models;
using TaskProject_Purus.Entity.QuoteRepository;
namespace TaskProject_Purus.Web.Controllers.Queries
{
    public  class CustomerdetailsQueries
    {
        private IQuoteRepository quoteRepository;
        private ICustomerRepository customerRepository;
        public CustomerdetailsQueries()
        {
            this.quoteRepository = new QuoteRepository(new Customercontext());
            this.customerRepository = new CustomerRepository(new Customercontext());
        }
       public  CustomerDetail details(CustomerRegisterModel model)
        {
            var customer = new CustomerDetail();
            var DOB = new DateTime(model.Birthyear, model.Birthmonth, model.Birthday);
            customer.Firstname = model.FristName;
            customer.Lastname = model.LastName;
            customer.CustomerID = model.CustomerID;
            customer.Location = model.location;
            customer.DateCreated = DateTime.Now;
            customer.TypeofInsurance = model.TypeofInsurance;
            customer.Amount = model.Amount;
            customer.DateofBirth = DOB;
            customer.CustomerAge = DateTime.Now.Year - DOB.Year;
            customer.NumOfYears = model.NumOfYears;
            customer.Status = false;
            return customer;
        }
        public IQueryable<CustomerDetail> GetCustomerByCustomerId(int customerId)
       {
         return  customerRepository.GetCustomerByCustomerId(customerId);
       }
        public  Quote GetQuotebyId(int quoteId)
       {
          return quoteRepository.GetQuoteById(quoteId);
       }

       public void InsertCustomer(CustomerDetail model)
        {
            customerRepository.InsertCustomer(model);
            customerRepository.Save();
        }
       
    }
}