using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject_Purus.Entity;
using TaskProject_Purus.Entity.CustomerRepository;
namespace TaskProject_Purus.Core.Extensions
{
    public static class CustomerExtensions
    {
        public static IQueryable<CustomerDetail> GetCustomersByInsurance(this IQueryable<CustomerDetail> details, string insurance)
        {
            return details.Where(x => x.TypeofInsurance == insurance).AsQueryable();
        }
        public static IQueryable<CustomerDetail> GetCustomersByLocation(this IQueryable<CustomerDetail> details, string location)
        {
            return details.Where(x => x.Location.Contains(location));
        }
        public static IQueryable<CustomerDetail> GetCustomersByFistName(this IQueryable<CustomerDetail> details, string firstname)
        {
            return details.Where(x => x.Firstname.Contains(firstname));
        }
        public static IQueryable<CustomerDetail> GetCustomersByLastName(this IQueryable<CustomerDetail> details, string lastname)
        {
            return details.Where(x => x.Lastname.Contains(lastname));
        }
        public static IQueryable<CustomerDetail> GetCustomersByAge(this IQueryable<CustomerDetail> details, int age, string equality)
        {
            if (!string.IsNullOrEmpty(equality))
            {
                if (equality == "=")
                {
                    return details.Where(x => x.CustomerAge == age);
                }
                if (equality == ">=")
                {
                    return details.Where(x => x.CustomerAge >= age);
                }
                if (equality == "<=")
                {
                    return details.Where(x => x.CustomerAge <= age);
                }
                if (equality == ">")
                {
                    return details.Where(x => x.CustomerAge > age);
                }
                if (equality == "<")
                {
                    return details.Where(x => x.CustomerAge < age);
                }
            }

            return details.Where(x => x.CustomerAge == age);

        }

        public static IQueryable<CustomerDetail> GetCustomersByAmount(this IQueryable<CustomerDetail> details, double amount, string equality)
        {
            if (!string.IsNullOrEmpty(equality))
            {
                if (equality == "=")
                {
                    return details.Where(x => x.Amount == amount);
                }
                if (equality == ">=")
                {
                    return details.Where(x => x.Amount >= amount);
                }
                if (equality == "<=")
                {
                    return details.Where(x => x.Amount <= amount);
                }
                if (equality == ">")
                {
                    return details.Where(x => x.Amount > amount);
                }
                if (equality == "<")
                {
                    return details.Where(x => x.Amount < amount);
                }
            }

            return details.Where(x => x.Amount == amount);

        }
        public static IQueryable<CustomerDetail> GetCustomersByYears(this IQueryable<CustomerDetail> details, int years, string equality)
        {
            if (!string.IsNullOrEmpty(equality))
            {
                if (equality == "=")
                {
                    return details.Where(x => x.NumOfYears == years);
                }
                if (equality == ">=")
                {
                    return details.Where(x => x.NumOfYears >= years);
                }
                if (equality == "<=")
                {
                    return details.Where(x => x.NumOfYears <= years);
                }
                if (equality == ">")
                {
                    return details.Where(x => x.NumOfYears > years);
                }
                if (equality == "<")
                {
                    return details.Where(x => x.NumOfYears < years);
                }
            }

            return details.Where(x => x.NumOfYears == years);

        }
        public static IQueryable<CustomerDetail> GetCustomersByStatus(this IQueryable<CustomerDetail> details, bool status)
        {
            return details.Where(x => x.Status == status);

        }
    }
}
