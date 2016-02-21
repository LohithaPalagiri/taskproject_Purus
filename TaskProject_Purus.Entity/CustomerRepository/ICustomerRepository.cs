using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject_Purus.Entity.CustomerRepository
{
    public interface ICustomerRepository : IDisposable
    {
        IQueryable<CustomerDetail> GetCustomers();
        void InsertCustomer(CustomerDetail customer);
        void UpdateCustomer(CustomerDetail customer);
        CustomerDetail GetCustomerByID(int customerId);
        IQueryable<CustomerDetail> GetCustomersByLocation(string customerLocation);
        IQueryable<CustomerDetail> GetCustomersByInsurance(string customerInsurance);
        IQueryable<CustomerDetail> GetCustomerByCustomerId(int customerId);
        void Save();
    }
}
