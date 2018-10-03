using Airport.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Airport.WebUI.Areas.Administrator.Controllers
{
    [Authorize(Roles = "Administrator, Developer, Manager")]
    public class PassengersController : Controller
    {
        DBContext db = new DBContext();

        public PassengersController()
        {
            ViewBag.Controller = "Passengers";
        }

        // GET: Administrator/Passengers
        public ActionResult Index()
        {
            return View(db.Passengers.Include("PassengerFlights").OrderBy(x=>x.LastName).ToList());
        }
    }
}