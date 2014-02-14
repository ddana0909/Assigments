using System.Linq;
using System.Web.Mvc;
using TravelAgency.DAL;
using TravelAgency.Models;


namespace TravelAgency.Controllers
{
    public class HomeController : Controller
    {
        private readonly TravelAgencyEntities db = new TravelAgencyEntities();

        private ITravelAgencyRepository Repository;

        public HomeController(ITravelAgencyRepository repository)
        {
            Repository = repository;
        }
       

        public ActionResult Index()
        {
            var trips = Repository.GetAllTrips();
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View(trips.ToList());
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
