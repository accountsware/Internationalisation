using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MvcInternationalization.Helpers;

namespace MvcInternationalization
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public override string GetVaryByCustomString(HttpContext context, string custom)
        {            
            if (custom == "culture") // culture name (e.g. "en-US") is what should vary caching
            {
                string cultureName = null;
              
                // Attempt to read the culture cookie from Request
                HttpCookie cultureCookie = Request.Cookies["_culture"];
                if (cultureCookie != null) {
                    cultureName = cultureCookie.Value;
                }
                else {
                    cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ? Request.UserLanguages[0] : null; // obtain it from HTTP header AcceptLanguages
                }
                
                // Validate culture name
                cultureName = CultureHelper.GetImplementedCulture(cultureName);

                return cultureName.ToLower(); // use culture name as the cache key, "es", "en-us", "es-cl", etc.
            }

            return base.GetVaryByCustomString(context, custom);
        } 
    }
}
