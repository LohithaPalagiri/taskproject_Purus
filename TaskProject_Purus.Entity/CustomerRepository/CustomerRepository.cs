using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject_Purus.Entity.CustomerRepository
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        private Customercontext context;
        public CustomerRepository(Customercontext context)
        {
            this.context = context;
        }

        public IQueryable<CustomerDetail> GetCustomers()
        {
            return context.CustomerDetails;
        }

        public CustomerDetail GetCustomerByID(int id)
        {
            return context.CustomerDetails.Find(id);
        }

        public void InsertCustomer(CustomerDetail customer)
        {
            context.CustomerDetails.Add(customer);
        }
        public void UpdateCustomer(CustomerDetail customer)
        {

            context.Entry(customer).State = System.Data.EntityState.Modified;
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public IQueryable<CustomerDetail> GetCustomersByLocation( string customerLocation)
        {
            return context.CustomerDetails.Where(x => x.Location == customerLocation);
        }
        public IQueryable<CustomerDetail> GetCustomersByInsurance(string customerInsurance)
        {
            return context.CustomerDetails.Where(x => x.TypeofInsurance == customerInsurance);
        }
        public IQueryable<CustomerDetail> GetCustomerByCustomerId(int customerId)
        {
            return context.CustomerDetails.Where(x => x.CustomerID == customerId);
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
