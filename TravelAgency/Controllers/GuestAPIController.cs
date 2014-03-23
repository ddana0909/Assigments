using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TravelAgency.Models;
using TravelAgency.DAL;

namespace TravelAgency.Controllers
{
    public class GuestApiController : ApiController
    {
        private ITravelAgencyRepository _repo;
        public GuestApiController(ITravelAgencyRepository repo)
        {
            _repo = repo;
        }
        
        // GET api/guestapi
        
        
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/guestapi/5
        public Guest GetGuest(int id)
        {
            var guest = _repo.GetGuestById(id);
            if (guest == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return guest;
       
        }

         [AcceptVerbs("POST")]
        public HttpResponseMessage Post(Guest guest)
        {
            if (ModelState.IsValid)
            {
                _repo.AddGuest(guest);

                //The new Student is written into the body of the response
                var response = Request.CreateResponse<Guest>(HttpStatusCode.Created, guest);

                //Let them know where the new Student is
                string uri = Url.Route("DefaultApi", new { id = guest.Id, action = "GetGuest" });
                response.Headers.Location = new Uri(Request.RequestUri, uri);
                return response;
            }
            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        // PUT api/guestapi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/guestapi/5
        public void Delete(int id)
        {
        }
    }
}
