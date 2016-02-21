using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskProject_Purus.Entity;
using TaskProject_Purus.Web.Controllers.Queries;
namespace TaskProject_Purus.Web.Controllers.CustomerDetails
{
    public class CustomerDetailsController : Controller
    {
        //
        // GET: /CustomerDetails/
       private CustomerdetailsQueries _CustomerQueries=new CustomerdetailsQueries(); 
        public ActionResult Index(int id)
        {
            var query = _CustomerQueries.GetCustomerByCustomerId(id).ToList();
            return View(query);
        }

        [HttpPost]
        public ActionResult GetQuoteById(int quoteId)
        {
            
            var quote = _CustomerQueries.GetQuotebyId(quoteId);
            return PartialView("_QuoteDetailPartial", quote);
        }

    }
}
