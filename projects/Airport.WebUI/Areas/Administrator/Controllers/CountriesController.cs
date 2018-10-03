using Airport.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Airport.WebUI.Areas.Administrator.Controllers
{
    [Authorize(Roles = "Administrator, Developer")]
    public class CountriesController : Controller
    {
        DBContext db = new DBContext();

        public CountriesController()
        {
            ViewBag.Controller = "Countries";
        }



        // GET: Administrator/Countries
        public ActionResult Index()
        {
            return View(db.Countries.OrderBy(x=>x.Name).ToList());
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Country country)
        {
            country.Id = Guid.NewGuid();
            db.Countries.Add(country);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            return View(db.Countries.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Country country)
        {
           Country dbEntry= db.Countries.Find(country.Id);
            dbEntry.Name = country.Name;
            db.SaveChanges();
            return View("Edit", db.Countries.Find(country.Id));
        }


        public ActionResult Delete(Guid id)
        {
            return View(db.Countries.Find(id));
        }

        [HttpPost]
        public ActionResult DeleteAction(Guid id)
        {
            db.Countries.Remove(db.Countries.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}