using TravelAgency.Models;
using System.Web.Mvc;

namespace TravelAgency.Controllers
{
    public class LegController : Controller
    {
        

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       
    }
}
