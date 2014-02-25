using System;
using System.Collections.Generic;
using System.Linq;
using TravelAgency.DAL;
using System.Web.Mvc;
using TravelAgency.Models;

namespace TravelAgency.Controllers
{
    public class LegController : Controller
    {
        private readonly ITravelAgencyRepository _repository;

        public LegController(ITravelAgencyRepository repository)
        {
            _repository = repository;
        }


        public ActionResult Create()
        {
            ViewBag.TripList = _repository.GetAllTrips().Select(t => new { id = t.Id, value = t.Name }).Distinct();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Leg newLeg)
        {
            if (ModelState.IsValid)
            {

                _repository.AddLeg(newLeg);
                UpdateComplete(newLeg.TripId);

                return RedirectToAction("Index", "Home");
            }


            ViewBag.TripList = _repository.GetAllTrips().Select(t => new { id = t.Id, value = t.Name }).Distinct();
            return View();

        }

        public bool IsDateInLegs(DateTime date, IEnumerable<Leg> legs)
        {
             foreach (var leg in legs)
                {
                    if (DateTime.Compare(date, leg.StartDate)>=0 
                        && DateTime.Compare(date,leg.FinishDate)<=0)
                    {
                        return true;

                    }
                    if (DateTime.Compare(date,leg.StartDate)<0)

                    {
                        return false;
                    }

                }
            return false;
        }

        public bool IsComplete(Trip trip)
        {
            var tripStartDate = trip.StartDate;
            var tripEndDate = trip.FinishDate;
            var legs = _repository.GetLegsForTrip(trip.Id);

            while (tripStartDate <= tripEndDate)
            {
               if(!IsDateInLegs(tripStartDate, legs))
                   return false;
               tripStartDate=tripStartDate.AddDays(1);
            }
            return true;

        }

        public void UpdateComplete(int tripId)
        {
            var trip = _repository.GetTrip(tripId);
            if (IsComplete(trip))
            {
                trip.Complete = true;
                _repository.UpdateTrip(trip);
            }
        }

        public bool IsViable(Trip trip)
        {

            return true;
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
        [HttpPost]
        public JsonResult StartDateOutsideTrip(DateTime startdate, int tripId)
        {
            var trip = _repository.GetTrip(tripId);

            if (DateTime.Compare(startdate, trip.StartDate) < 0)
                return Json(false, JsonRequestBehavior.AllowGet);

            if (DateTime.Compare(startdate, trip.FinishDate) > 0)
                return Json(false, JsonRequestBehavior.AllowGet);
            
            return Json(true,JsonRequestBehavior.AllowGet);

            //return
            //    Json(!(DateTime.Compare(startdate, trip.StartDate) < 0 
            //            || DateTime.Compare(startdate, trip.FinishDate) > 0),JsonRequestBehavior.AllowGet);


        }

        public JsonResult FinishDateOutsideTrip(DateTime finishdate, int tripId)
        {
            var trip = _repository.GetTrip(tripId);
            return Json(!(DateTime.Compare(finishdate, trip.StartDate) < 0 
                       || DateTime.Compare(finishdate, trip.FinishDate) > 0),JsonRequestBehavior.AllowGet);

        }
    }
}
