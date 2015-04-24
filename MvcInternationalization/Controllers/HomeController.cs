using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcInternationalization.Helpers;
using MvcInternationalization.Models;

namespace MvcInternationalization.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(Person per)
        {
            return View();
        }

        public ActionResult SetCulture(string culture)
        {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);

            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {

                cookie = new HttpCookie("_culture");                
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);

            return RedirectToAction("Index");
        }                

 
    }
}