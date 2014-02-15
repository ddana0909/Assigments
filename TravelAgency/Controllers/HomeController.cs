using System.Linq;
using System.Web.Mvc;
using TravelAgency.DAL;


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
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View(trips.ToList());
        }

        public ActionResult TripDetails(int tripId)
        {
            var legs = _repository.GetLegsForTrip(tripId);
            return PartialView("_LegList", legs);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
