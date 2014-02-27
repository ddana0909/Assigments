using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TravelAgency.DAL;
using TravelAgency.HelperClasses;
using TravelAgency.Models;


namespace TravelAgency.Controllers
{
    public class HomeController : Controller
    {


        private readonly ITravelAgencyRepository _repository;

        public HomeController(ITravelAgencyRepository repository)
        {
            _repository = repository;
        }


        public ActionResult Index()
        {
            var trips = _repository.GetAllTrips();
            return View(trips.ToList());
        }

        public ActionResult TripDetails(int tripId)
        {
            var legs = _repository.GetLegsForTrip(tripId);
            return PartialView("_LegList", legs);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Trip trip)
        {
            if (ModelState.IsValid)
            {
                trip.Viable = false;
                trip.Complete = false;
                trip.PicturePath = "~/Images/default.jpg";

                _repository.AddTrip(trip);

                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult GetGuestsOnLeg(int legId)
        {
            var guests = _repository.GetGuestsOnLeg(legId);
            if (!guests.Any())
                ViewBag.NoGuests = "empty";
            var leg = _repository.GetLeg(legId);
            ViewBag.Start = leg.StartLocation;
            ViewBag.Finish = leg.FinishLocation;
            ViewBag.LegId = leg.Id;
            return PartialView("_GuestList", guests);
        }

        public ActionResult GetProgressBar(int tripId)
        {

            var trip = _repository.GetTrip(tripId);
            var legs = _repository.GetLegsForTrip(tripId);
            string[] cssClasses = new string[3] { "progress-bar progress-bar-success", 
                                                  "progress-bar progress-bar-info", 
                                                  "progress-bar progress-bar-warning"}
                                                  ;


            var tripPeriod = trip.FinishDate.Subtract(trip.StartDate).TotalDays;
            var list = new List<TripTimelineElement>();
            int i = 0;
            var auxFinish = trip.StartDate;
            foreach (var leg in legs)
            {

                //inseamna ca avem gap
                if (auxFinish != leg.StartDate)
                {
                    var period = leg.StartDate.Subtract(auxFinish).TotalDays;
                    var yyy = new TripTimelineElement
                    {
                        StartDate = auxFinish.ToShortDateString(),
                        FinishDate = leg.StartDate.ToShortDateString(),
                        Percentage = (int)(period / tripPeriod * 100),
                        CssClass = "progress-bar progress-bar-danger",
                        NotPlanned = true
                    };

                    list.Add(yyy);
                }

                {
                    var legPeriod = leg.FinishDate.Subtract(leg.StartDate).TotalDays;
                    var yyy = new TripTimelineElement
                    {
                        Percentage = (int)(legPeriod / tripPeriod * 100),
                        StartDate = leg.StartDate.ToShortDateString(),
                        FinishDate = leg.FinishDate.ToShortDateString(),
                        CssClass = "progress-bar progress-bar-success",
                        NotPlanned = false

                    };
                    list.Add(yyy);
                }
              
                auxFinish = leg.FinishDate;
            }
            if(auxFinish!=trip.FinishDate)
                list.Add(
            new TripTimelineElement{
                Percentage=(int)(trip.FinishDate.Subtract(auxFinish).TotalDays/tripPeriod*100),
                StartDate = auxFinish.ToShortDateString(),
                FinishDate = trip.FinishDate.ToShortDateString(),
                CssClass = "progress-bar progress-bar-danger",
                NotPlanned = true
            }
        );
            

            return View("_TimeLine", list);
        }
    }
}
