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

            var tripPeriod = trip.FinishDate.Subtract(trip.StartDate).TotalDays;
            var list = new List<TripTimelineElement>();

            var auxFinish = trip.StartDate;
            var progress = 0;
            foreach (var leg in legs)
            {

                if (auxFinish != leg.StartDate)
                {
                    var period = leg.StartDate.Subtract(auxFinish).TotalDays;
                    var yyy = new TripTimelineElement
                    {
                        StartDate = auxFinish.ToString("dd/MM"),
                        FinishDate = leg.StartDate.ToString("dd/MM"),
                        Percentage = (int)(period / tripPeriod * 100),
                        CssClass = "progress-bar progress-bar-danger",
                        NotPlanned = true
                    };
                    progress += yyy.Percentage;

                    list.Add(yyy);
                }

                {
                    var legPeriod = leg.FinishDate.Subtract(leg.StartDate).TotalDays;
                    var yyy = new TripTimelineElement
                    {
                        Percentage = (int)(legPeriod / tripPeriod * 100),
                        StartDate = leg.StartDate.ToString("dd/MM"),
                        FinishDate = leg.FinishDate.ToString("dd/MM"),
                        CssClass = "progress-bar progress-bar-success",
                        NotPlanned = false

                    };
                    list.Add(yyy);
                    progress += yyy.Percentage;
                }

                auxFinish = leg.FinishDate;
            }
            if (auxFinish != trip.FinishDate)
            {

                var yyy = new TripTimelineElement
                 {
                     Percentage = (int)(trip.FinishDate.Subtract(auxFinish).TotalDays / tripPeriod * 100),
                     StartDate = auxFinish.ToString("dd/MM"),
                     FinishDate = trip.FinishDate.ToString("dd/MM"),
                     CssClass = "progress-bar progress-bar-danger",
                     NotPlanned = true
                 };
                list.Add(yyy);
                progress += yyy.Percentage;
            }

            if (progress != 100)
            {
                list.Last().Percentage += (100 - progress);
            }

            return PartialView("_TimeLine", list);
        }
    }
}
