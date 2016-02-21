using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskProject_Purus.Web.Models
{
    public class SearchCustomerViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TypeofInsurance { get; set; }
        public string Amount { get; set; }
        public string NumOfYears { get; set; }
        public string location { get; set; }
        public string Age { get; set; }
        public string AgeEquality { get; set; }
        public string YearsEuality { get; set; }
        public string AmountEuality { get; set; }
        public bool Status { get; set; }
        public List<SearchCustomerDetails> SearchResults { get; set; }

    }
}