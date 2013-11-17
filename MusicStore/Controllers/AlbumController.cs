using MusicStore.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class AlbumController : Controller
    {
        private readonly MvcMusicStoreEntities db;

        public AlbumController()
        {
            db = new MvcMusicStoreEntities();
        }

        public ActionResult Index(int id = 0)
        {
            if (id != 0)
            {
                var albums = new List<Album>();

                Order order = db.Orders.Find(id);
                albums.AddRange(order.OrderDetails.Select(od => od.Album));
                return View(albums);
            }

            else
            {
	            var albums = db.Albums.Include(a => a.Artist).Include(a => a.Genre);
                return View(albums.ToList());
            }
        }

	    public ActionResult IndexArtist(int id = 0)
	    {
		    return View();
	    }

	    protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}