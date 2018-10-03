using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Airport.WebUI.Models;

namespace Airport.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Active = "Home";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Active = "About";
            return View();
        }
        
        public ActionResult Contacts()
        {
            ViewBag.Active = "Contacts";
            return View();
        }

    }
}