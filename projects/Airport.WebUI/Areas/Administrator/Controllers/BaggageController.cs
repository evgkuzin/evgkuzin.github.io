using Airport.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Airport.WebUI.Areas.Administrator.Controllers
{
    public class BaggageController : Controller
    {
        DBContext db = new DBContext();

        public BaggageController()
        {
            ViewBag.Controller = "Baggage";
        }

        // GET: Administrator/Baggage
        public ActionResult Index()
        {
            IEnumerable<PassengerFlight> passengerFlight = db.PassengerFlights.Where(x => x.FlightId == x.BaggageCode).ToList();
            ViewBag.Info = null;
            return View(passengerFlight);
        }

        [HttpPost]
        public ActionResult Index(string codeword)
        {
            ViewBag.Info = "Информация не найдена";
            try
            {
                var baggageCode = Guid.Parse(codeword);
                var pf = db.PassengerFlights.Include("Flight").Include("Passenger").FirstOrDefault(x => x.BaggageCode == baggageCode);
                if (pf != null)
                {
                    ViewBag.Data = pf;
                    ViewBag.aD = db.Airports.Find(pf.Flight.AirportDepartureId).City;
                    ViewBag.Info = "Информация найдена";
                }
            }
            catch (Exception)
            {
                ViewBag.Data = null;
            }
            return View();
        }



    }
}