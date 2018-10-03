using Airport.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Airport.WebUI.Areas.Administrator.Controllers
{
    [Authorize(Roles = "Administrator, Developer")]
    public class FlightsController : Controller
    {
        DBContext db = new DBContext();

        public FlightsController()
        {
            ViewBag.Controller = "Flights";
        }

        // GET: Administrator/Airports
        public ActionResult Index()
        {
            ViewBag.Airports = db.Airports.ToList();
            return View(db.Flights.OrderBy(x => x.Airport.City).ToList());
        }

        public ActionResult Create()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Value = null, Text = "-- Не выбрано --" });

            IEnumerable<WebUI.Models.Airport> airports = db.Airports.OrderBy(x => x.City).ToList();
            foreach (WebUI.Models.Airport item in airports)
            {
                list.Add(new SelectListItem() { Value = item.Id.ToString(), Text =item.City + " | " + item.Name });
            }

            SelectList selectList = new SelectList(list, "Value", "Text");
            //var selected = selectList.Where(x => x.Value == slide.LinkPageId.ToString()).FirstOrDefault();
            //if (selected != null) selected.Selected = true;
            ViewBag.selectList = selectList;

            return View();
        }

        [HttpPost]
        public ActionResult Create(Flight flight)
        {
            flight.Id = Guid.NewGuid();
            db.Flights.Add(flight);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}