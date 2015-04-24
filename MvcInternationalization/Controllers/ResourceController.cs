using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExtensionMethods;

using Resource = Resources.Resources;

namespace MvcInternationalization.Controllers
{
    public class ResourceController : BaseController
    {
        // GET: /Resource/GetResources
        const int durationInSeconds = 2 * 60 * 60;  // 2 hours.

        [OutputCache(VaryByCustom = "culture", Duration = durationInSeconds)]
        public JsonResult GetResources()
        {

            return Json(
                typeof(Resource)
                .GetProperties()
                .Where(p => !p.Name.IsLikeAny("ResourceManager", "Culture")) // Skip the properties you don't need on the client side.
                .ToDictionary(p => p.Name, p => p.GetValue(null) as string)
                 , JsonRequestBehavior.AllowGet);

            // Or the following 
            /*
            return Json(new Dictionary<string, string> { 
                {"Age", Resource.Age},
                {"FirstName", Resource.FirstName},
                {"LastName", Resource.LastName},
                {"EnterNumber", Resource.EnterNumber}
                   
            }, JsonRequestBehavior.AllowGet);
            */


        }
    }
}