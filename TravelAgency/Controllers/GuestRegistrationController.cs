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
        
        
        //
        // GET: /GuestRegistration/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /GuestRegistration/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /GuestRegistration/Create

        public ActionResult Create(int legId)
        {
            ViewBag.GuestList = _repository.GetGuests().Select(g=>new{id=g.Id, value=g.FirstName}).Distinct();
            ViewBag.LegId = legId;
            return PartialView();
        }

        //
        // POST: /GuestRegistration/Create

        [HttpPost]
        public ActionResult Create(GuestRegistration registration)
        {
            if (ModelState.IsValid)
            {
                _repository.AddGuestRegistration(registration);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.GuestList = _repository.GetGuests().Select(g => new { id = g.Id, value = g.FirstName }).Distinct();
            ViewBag.LegId = registration.LegId;
            return PartialView();
        }



        //
        // GET: /GuestRegistration/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /GuestRegistration/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /GuestRegistration/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /GuestRegistration/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public JsonResult IsAlreadyRegistered(int guestid, int legid)
        {
            return Json(_repository.GetGuestRegistrationsByLegAndGuest(legid, guestid).Any(),
                JsonRequestBehavior.AllowGet);
        }
    }
    }

