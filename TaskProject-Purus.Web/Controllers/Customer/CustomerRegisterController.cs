using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskProject_Purus.Entity;
using TaskProject_Purus.Entity.CustomerRepository;
using TaskProject_Purus.Web.Controllers.Queries;
using TaskProject_Purus.Web.Filters;
using TaskProject_Purus.Web.Models;
using WebMatrix.WebData;
namespace TaskProject_Purus.Web.Controllers.Customer
{
    [InitializeSimpleMembership]
    public class CustomerRegisterController : Controller
    {

        private CustomerdetailsQueries _CustomerQueries = new CustomerdetailsQueries();


        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(CustomerRegisterModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (User != null && User.Identity != null && User.Identity.IsAuthenticated)
                    {
                        model.Email = User.Identity.Name;
                    }
                    else
                    {
                        var x = WebSecurity.CreateUserAndAccount(model.Email, model.Password);
                        WebSecurity.Login(model.Email, model.Password);
                    }

                    model.CustomerID = WebSecurity.GetUserId(model.Email);
                    var customer = _CustomerQueries.details(model);
                    _CustomerQueries.InsertCustomer(customer);
                    return RedirectToAction("Index", "CustomerDetails", new { id = model.CustomerID });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View(model);
        }




    }
}
