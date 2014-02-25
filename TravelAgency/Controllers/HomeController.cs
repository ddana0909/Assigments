using System.Linq;
using System.Web.Mvc;
using TravelAgency.DAL;
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
            return PartialView("_GuestList",guests);
        }
    }
}
