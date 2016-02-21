using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskProject_Purus.Web.Models
{
    public class CustomerRegisterModel
    {
              
        public string FristName { get; set; }
        public string LastName { get; set; }     
      
        public string Email { get; set; }
        public string Password { get; set; }
        public int CustomerID { get;set; }
        public int Birthday { get; set; }
        public int Birthmonth { get; set; }
        public int Birthyear { get; set; }
        public string TypeofInsurance { get; set; }
        public double Amount { get; set; }
        public int NumOfYears { get; set; }
        public string location { get; set; }
    }
}