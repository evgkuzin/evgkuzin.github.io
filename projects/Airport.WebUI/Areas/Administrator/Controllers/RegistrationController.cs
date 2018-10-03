using Airport.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Airport.WebUI.Areas.Administrator.Controllers
{
    [Authorize(Roles = "Administrator, Developer, Manager")]
    public class RegistrationController : Controller
    {
        DBContext db = new DBContext();

        public RegistrationController()
        {
            ViewBag.Controller = "Registration";
        }

        // GET: Administrator/Registration
        public ActionResult Index()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            //list.Add(new SelectListItem() { Value = null, Text = "-- Не выбрано --" });

            IEnumerable<Flight> flights = db.Flights.OrderBy(x => x.AirportDepartureId).ToList();
            foreach (Flight item in flights)
            {
                var aD = db.Airports.Find(item.AirportDepartureId);
                list.Add(new SelectListItem() { Value = item.Id.ToString(), Text = aD.City + " (" + item.TimeArrival + ") - " + item.Airport.City + " (" + item.TimeDeparture + ")" });
            }
            SelectList selectList = new SelectList(list, "Value", "Text");
            ViewBag.selectList = selectList;

            return View();
        }

        [HttpPost]
        public ActionResult Booking(Passenger passenger, Guid flightId, string dateVal, string bagagge)
        {
            passenger.Id = Guid.NewGuid();
            PassengerFlight passengerFlight = new PassengerFlight { Id = Guid.NewGuid(), PassengerId = passenger.Id, FlightId = flightId, DateDeparture = DateTime.Parse(dateVal) };
            if (bagagge == "1") passengerFlight.BaggageCode = Guid.NewGuid();
            db.Passengers.Add(passenger);
            db.PassengerFlights.Add(passengerFlight);
            db.SaveChanges();



            return RedirectToAction("Details", new { passengerId = passenger.Id });
        }

        public ActionResult Details(Guid passengerId)
        {
            var pf = db.PassengerFlights.Include("Flight").Include("Passenger").FirstOrDefault(x => x.PassengerId == passengerId);
            ViewBag.Data = pf;
            ViewBag.aD = db.Airports.Find(pf.Flight.AirportDepartureId).City;
            return View("Details", pf.Passenger);
        }

    }
}