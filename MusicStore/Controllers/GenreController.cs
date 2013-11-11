using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class GenreController : Controller
    {
       private MvcMusicStoreEntities db = new MvcMusicStoreEntities();
        //
        // GET: /Genre/

        public ActionResult Index()
        {
            return View(db.Genres);
        }

        //
        // GET: /Genre/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Genre/Create

        public ActionResult Create()
        {
            
            return View();
        }

        //
        // POST: /Genre/Create

        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            try
            {
                using (var context = new MvcMusicStoreEntities())
                {
                    context.Genres.Add(genre);
                    context.SaveChanges();
                }
                   
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Genre/Edit/5

        public ActionResult Edit(int id)
        {
            //Genre genre = db.Genres.Find(id);
            Genre genre = db.Genres.SingleOrDefault(ent => ent.GenreId == id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
            //return View();
        }

        //
        // POST: /Genre/Edit/5

        [HttpPost]
        public ActionResult Edit(Genre genre)
        {
            try
            {
                using (var db = new MvcMusicStoreEntities())
                {
                    db.Entry(genre).State=EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Genre/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Genre/Delete/5

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

        protected override void Dispose(bool disposing)
        {   db.Dispose();
            base.Dispose(disposing);
        }
    }
}
