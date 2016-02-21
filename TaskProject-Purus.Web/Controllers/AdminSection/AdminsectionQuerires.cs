using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskProject_Purus.Entity;
using TaskProject_Purus.Entity.CustomerRepository;
using TaskProject_Purus.Web.Models;
using TaskProject_Purus.Core.Extensions;
using TaskProject_Purus.Entity.QuoteRepository;
using TaskProject_Purus.Web.Controllers.Queries;
namespace TaskProject_Purus.Web.Controllers.AdminSection
{
    public class AdminsectionQuerires
    {
        private ICustomerRepository customerRepository;
        private IQuoteRepository quoteRepository;
        public AdminsectionQuerires()
        {
            this.quoteRepository = new QuoteRepository(new Customercontext());
            this.customerRepository = new CustomerRepository(new Customercontext());
        }
        public IQueryable<CustomerDetail> GetCustomerDetails(SearchCustomerViewModel model)
        {
            var query = customerRepository.GetCustomers();
            if (model == null) return query;
            if (!string.IsNullOrEmpty(model.TypeofInsurance))
            {
                query = query.GetCustomersByInsurance(model.TypeofInsurance);

            }
            if (!string.IsNullOrEmpty(model.FirstName))
            {
                query = query.GetCustomersByFistName(model.FirstName);
            }
            if (!string.IsNullOrEmpty(model.LastName))
            {
                query = query.GetCustomersByLastName(model.LastName);
            }
            if (!string.IsNullOrEmpty(model.location))
            {
                query = query.GetCustomersByLocation(model.location);
            }
            int age;
            if (!string.IsNullOrEmpty(model.AgeEquality) && !string.IsNullOrEmpty(model.Age) && int.TryParse(model.Age, out age))
            {
                query = query.GetCustomersByAge(age, model.AgeEquality);
            }
            int years;
            if (!string.IsNullOrEmpty(model.YearsEuality) && !string.IsNullOrEmpty(model.NumOfYears) && int.TryParse(model.NumOfYears, out years))
            {
                query = query.GetCustomersByYears(years, model.YearsEuality);

            }
            double amount;
            if (!string.IsNullOrEmpty(model.AmountEuality) && !string.IsNullOrEmpty(model.AmountEuality) && double.TryParse(model.Amount, out amount))
            {
                query = query.GetCustomersByAmount(amount, model.AmountEuality);
            }
            query = query.GetCustomersByStatus(model.Status);
            return query.OrderByDescending(x => x.DateCreated);
        }
        public List<SearchCustomerDetails> GetSearchCustomerDetails(SearchCustomerViewModel model)
        {
            var results = GetCustomerDetails(model);

            var res = results.Select(x => new SearchCustomerDetails()
            {
                Fullname = string.Concat(x.Firstname, " ", x.Lastname),
                CustomerAge = x.CustomerAge,
                NumOfYears = x.NumOfYears,
                Amount = x.Amount,
                Status = x.Status.Value,
                TypeofInsurance = x.TypeofInsurance,
                Location = x.Location,
                CustomerID = x.CustomerID,
                ID = x.ID
            });
            return res.ToList();
        }

        public List<string> GetLocationsForAutoFill(string term)
        {
            return customerRepository.GetCustomers().Where(x => x.Location.Contains(term)).Select(x => x.Location).ToList();
        }
        public List<string> GetFirstnamesForAutoFill(string firstname)
        {
            return customerRepository.GetCustomers().Where(x => x.Firstname.Contains(firstname)).Select(x => x.Firstname).ToList();
        }
        public List<string> GetLastnamesForAutoFill(string lastname)
        {
            return customerRepository.GetCustomers().Where(x => x.Lastname.Contains(lastname)).Select(x => x.Lastname).ToList();
        }

        public int CreateQuote(QuoteViewModel model)
        {
            var quote = QuoteQueries.CreateQuoteFromQuoteViewModel(model);
            var quoteId = quoteRepository.InsertQuoteAndGetId(quote);
            return quoteId;
        }
        public void UpdateCustomerWithQuoteIdAndStatus(int customerId, int quoteId)
        {
            var customer = customerRepository.GetCustomerByID(customerId);
            customer.QuoteID = quoteId;
            customer.Status = true;
            customerRepository.UpdateCustomer(customer);
            customerRepository.Save();
        }
        public IQueryable<Quote> GetAllQuotes()
        {
            return quoteRepository.GetQuotes();
        }
    }
}