using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CameraShop.Controllers
{
    public class InfoCompanyController : Controller
    {
        // GET: InfoCompany
        public ActionResult About()
        {
            return View("About");
        }
    }
}