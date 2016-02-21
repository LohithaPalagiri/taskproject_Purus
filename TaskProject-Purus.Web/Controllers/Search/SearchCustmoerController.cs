using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskProject_Purus.Web.Models;
using TaskProject_Purus.Entity;
namespace TaskProject_Purus.Web.Controllers.Search
{
    public class SearchCustmoerController : Controller
    {
        //
        // GET: /SearchCustmoer/
        Customercontext db = new Customercontext();
        [HttpPost]
        public ActionResult Index(SearchCustomerViewModel model)
        {
            var query = db.CustomerDetails.Where(x => x.TypeofInsurance == model.TypeofInsurance).ToList();
            return View(query);
        }
        public JsonResult GetAge(int term)
        {
            var query = db.CustomerDetails.Where(x => x.CustomerAge == term).Select(x => x.CustomerAge).ToList();
            return Json(query, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetLoaction(string term)
        {
            var query = db.CustomerDetails.Where(x => x.Location.StartsWith(term)).Select(x => x.Location).ToList();
            return Json(query, JsonRequestBehavior.AllowGet);

        }
    }
}
