//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaskProject_Purus.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerDetail
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Nullable<System.DateTime> DateofBirth { get; set; }
        public string TypeofInsurance { get; set; }
        public Nullable<double> Amount { get; set; }
        public Nullable<int> NumOfYears { get; set; }
        public int CustomerID { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string Location { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<int> CustomerAge { get; set; }
        public Nullable<int> QuoteID { get; set; }
    
        public virtual Quote Quote { get; set; }
    }
}
