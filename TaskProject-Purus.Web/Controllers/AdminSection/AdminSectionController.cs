using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskProject_Purus.Entity;
using TaskProject_Purus.Entity.CustomerRepository;
using TaskProject_Purus.Web.Models;

namespace TaskProject_Purus.Web.Controllers.AdminSection
{
    public class AdminSectionController : Controller
    {

        // GET: /AdminSection/
       
        AdminsectionQuerires adminQueries = new AdminsectionQuerires();
        [HttpGet]
        public ActionResult Index(SearchCustomerViewModel model)
        {
            try
            {
                model.SearchResults = adminQueries.GetSearchCustomerDetails(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult SearchResults(SearchCustomerViewModel model)
        {
            try
            {
                model.SearchResults = adminQueries.GetSearchCustomerDetails(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View(model);
        }


        public JsonResult GetLoaction(string term)
        {
            var query = adminQueries.GetLocationsForAutoFill(term);
            return Json(query, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetFirstnames(string term)
        {
            var query = adminQueries.GetFirstnamesForAutoFill(term);
            return Json(query, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetLastnames(string term)
        {
            var query = adminQueries.GetLastnamesForAutoFill(term);
            return Json(query, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public bool UpdateStatus(QuoteViewModel model)
        {
            try
            {
                var quoteId = adminQueries.CreateQuote(model);
                adminQueries.UpdateCustomerWithQuoteIdAndStatus(model.CustomerId, quoteId);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        [HttpPost]
        public ActionResult GetAllQuotes(int customerId)
        {
            var model = new AssignQuoteViewModel();
            model.CustomerId = customerId;
            model.ListOfQuotes = adminQueries.GetAllQuotes().ToList();
            return PartialView("_GetAllQuotesPartial", model);
        }

        [HttpPost]
        public JsonResult AssignExistingQuote(int customerId, int quoteId)
        {
            try
            {
                adminQueries.UpdateCustomerWithQuoteIdAndStatus(customerId, quoteId);
                return new JsonResult { Data = new { sucess = true, msg = "" } };
            }
            catch(Exception ex)
            {
                return new JsonResult { Data = new { sucess = false, msg = ex.Message } };
            }
        }
    }
}
