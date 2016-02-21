using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskProject_Purus.Entity;
namespace TaskProject_Purus.Web.Models
{
    public class AssignQuoteViewModel
    {
        public int CustomerId { get; set; }
        public List<Quote> ListOfQuotes { get; set; }
    }
}