using Airport.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Airport.WebUI.Areas.Administrator.Controllers
{
    [Authorize(Roles = "Administrator, Developer, Manager")]
    public class HomeController : Controller
    {
        DBContext db = new DBContext();
        string actionName;

        public HomeController()
        {
            ViewBag.Controller = "Home";
        }

        public ActionResult Index()
        {
            actionName = "Index";
            ViewBag.Action = actionName;

            ViewBag.Passengers = db.Passengers.Count().ToString();
            ViewBag.Flights = db.Flights.Count().ToString();
            ViewBag.Airports = db.Airports.Count().ToString();

            return View();
        }







    }
}