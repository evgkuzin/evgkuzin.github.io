//using ESL.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Airport.WebUI.Areas.Administrator.Controllers
{
    public class _PartialsController : Controller
    {
        [ChildActionOnly]
        public ActionResult _Menu(string controllerName)
        {
            ViewBag.Conroller = controllerName;
            return PartialView();
        }
    }
}