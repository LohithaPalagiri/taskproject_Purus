using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskProject_Purus.Entity;
namespace TaskProject_Purus.Web.Models
{
    public class SearchCustomerDetails
    {
        public string Fullname { get; set; }
        public int ID { get; set; }
        public string TypeofInsurance { get; set; }
        public Nullable<double> Amount { get; set; }
        public Nullable<int> NumOfYears { get; set; }
        public int CustomerID { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string Location { get; set; }
        public bool Status { get; set; }
        public Nullable<int> CustomerAge { get; set; }


    }
}