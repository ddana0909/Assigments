using System.Linq;
using System.Web.Mvc;
using TravelAgency.Models;

namespace TravelAgency.Controllers
{
    public class HomeController : Controller
    {
        private readonly TravelAgencyEntities db = new TravelAgencyEntities();
        
        public ActionResult Index()
        {
            

            db.Guests.Add(new Guest {FirstName = "vbakjdbvjsdl"});
            db.SaveChanges();


            var x = db.Guests;
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View(x.ToList());
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
