using Airport.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Airport.WebUI.Areas.Administrator.Controllers
{
    [Authorize(Roles = "Administrator, Developer")]
    public class AirportsController : Controller
    {
        DBContext db = new DBContext();

        public AirportsController()
        {
            ViewBag.Controller = "Airports";
        }

        public ActionResult Index()
        {
            return View(db.Airports.OrderBy(x=>x.City).ToList());
        }

        public ActionResult Create()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Value = null, Text = "-- Не выбрано --" });

            IEnumerable<Country> countries = db.Countries.OrderBy(x => x.Name).ToList();
            foreach (Country item in countries)
            {
                list.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.Name });
            }

            SelectList selectList = new SelectList(list, "Value", "Text");
            ViewBag.selectList = selectList;
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(WebUI.Models.Airport airport)
        {
            airport.Id = Guid.NewGuid();
            db.Airports.Add(airport);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            var airport = db.Airports.Find(id);
            List<SelectListItem> list = new List<SelectListItem>();
                        IEnumerable<Country> countries = db.Countries.OrderBy(x => x.Name).ToList();
            foreach (Country item in countries)
            {
                list.Add(new SelectListItem() { Value = item.Id.ToString(), Text = item.Name });
            }
                        SelectList selectList = new SelectList(list, "Value", "Text");
            var selected = selectList.Where(x => x.Value == airport.CountryId.ToString()).FirstOrDefault();
            if (selected != null) selected.Selected = true;
            ViewBag.selectList = selectList;

            return View(airport);
        }

        [HttpPost]
        public ActionResult Edit(WebUI.Models.Airport airport)
        {
            WebUI.Models.Airport dbEntry = db.Airports.Find(airport.Id);
            dbEntry.Name = airport.Name;
            dbEntry.City = airport.City;
            dbEntry.Code = airport.Code;
            dbEntry.CountryId = airport.CountryId;

            db.SaveChanges();
            return RedirectToAction("Edit", new { id=airport.Id });
        }

        public ActionResult Delete(Guid id)
        {
            return View(db.Airports.Find(id));
        }

        [HttpPost]
        public ActionResult DeleteAction(Guid id)
        {
            db.Airports.Remove(db.Airports.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}