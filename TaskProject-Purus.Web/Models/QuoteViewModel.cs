using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskProject_Purus.Web.Models
{
    public class QuoteViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public int QuoteId { get; set; }
    }
}