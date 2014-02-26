using System.Linq;
using System.Web.Mvc;
using TravelAgency.DAL;
using TravelAgency.Models;

namespace TravelAgency.Controllers
{
    public class GuestRegistrationController : Controller
    {
        private readonly ITravelAgencyRepository _repository;
        public GuestRegistrationController(ITravelAgencyRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Create(int legId)
        {
            ViewBag.GuestList = _repository.GetGuests().Select(g=>new{id=g.Id, value=g.FirstName}).Distinct();
            ViewBag.LegId = legId;
            
            
            return PartialView();
        }


        [HttpPost]
        public ActionResult Create(GuestRegistration registration)
        {
            if (ModelState.IsValid)
            {
                _repository.AddGuestRegistration(registration);
                var leg=_repository.GetLeg(registration.LegId);
                UpdateViable(leg.TripId);                 
                return RedirectToAction("Index", "Home");
            }
            ViewBag.GuestList = _repository.GetGuests().Select(g => new { id = g.Id, value = g.FirstName }).Distinct();
            ViewBag.LegId = registration.LegId;
            return PartialView();
        }

        public JsonResult IsAlreadyRegistered(int guestId , int legId)
        {
            return Json(_repository.GetGuestRegistrationsByLegAndGuest(legId, guestId).Any(),
                JsonRequestBehavior.AllowGet);
        }


        public void UpdateViable(int tripId)
        {
            var trip = _repository.GetTrip(tripId);
            if (IsViable(trip))
            {
                trip.Viable = true;
                _repository.UpdateTrip(trip);
            }
        }

        public bool IsViable(Trip trip)
        {
            return (_repository.GetNoGuestsOnTrip(trip.Id) >= trip.MinimumGuests);
        }
    }
    }

