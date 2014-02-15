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

            var x = trips.ToList();
            return View(trips.ToList());
        }

        public ActionResult TripDetails(int tripId)
        {
            var legs = _repository.GetLegsForTrip(tripId);
            var x = legs.ToList();
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
            trip.Viable = false;
            trip.Complete = false;
            trip.PicturePath = "~/Images/default.jpg";
            
            _repository.AddTrip(trip);          
            
            return RedirectToAction("Index");
        }



        
    }
}
