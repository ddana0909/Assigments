using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TravelAgency.DAL;
using TravelAgency.Models;

namespace TravelAgency.Controllers
{
    public class LegAPIController : ApiController
    {
        private ITravelAgencyRepository _repo;

        public LegAPIController(ITravelAgencyRepository repo)
        {
            _repo = repo;
        }
        private TravelAgencyEntities db = new TravelAgencyEntities();

        // GET api/LegAPI
        public IEnumerable<Object> GetLegs(int id)
        {
            return _repo.GetLegsApi(id);


        }

        // GET api/LegAPI/5
        //public Leg GetLegs(int id)
        //{
        //    Leg leg = db.Legs.Find(id);
        //    if (leg == null)
        //    {
        //        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        //    }

        //    return leg;
        //}

        // PUT api/LegAPI/5
        //public HttpResponseMessage PutLeg(int id, Leg leg)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }

        //    if (id != leg.Id)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }

        //    db.Entry(leg).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}

        //// POST api/LegAPI
        //public HttpResponseMessage PostLeg(Leg leg)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Legs.Add(leg);
        //        db.SaveChanges();

        //        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, leg);
        //        response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = leg.Id }));
        //        return response;
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }
        //}

        //// DELETE api/LegAPI/5
        //public HttpResponseMessage DeleteLeg(int id)
        //{
        //    Leg leg = db.Legs.Find(id);
        //    if (leg == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    db.Legs.Remove(leg);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, leg);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}