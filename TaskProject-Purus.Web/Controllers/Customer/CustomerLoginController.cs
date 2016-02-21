using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TaskProject_Purus.Web.Filters;
using TaskProject_Purus.Web.Models;
using WebMatrix.WebData;
namespace TaskProject_Purus.Web.Controllers.Customer
{
    [InitializeSimpleMembership]
    public class CustomerLoginController : Controller
    {
        //
        // GET: /CustomerLogin/

        public ActionResult Index()
        {
            if(Request.IsAuthenticated)
            {
                return RedirectToAction("Index", new RouteValueDictionary(
     new { controller = "CustomerDetails", action = "Index", id = WebSecurity.GetUserId(User.Identity.Name) }));
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(CustomerLoginModel model)
        {
            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password))
            {

                return RedirectToAction("Index", new RouteValueDictionary(
    new { controller = "CustomerDetails", action = "Index", id = WebSecurity.GetUserId(model.UserName) }));
            }
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction("Index", "HomePage");
        }


    }
}
