using System;
using System.Collections.Generic;
using System.Web.Http;
using TravelAgency.DAL;

namespace TravelAgency.Controllers
{
    public class LegApiController : ApiController
    {
        private readonly ITravelAgencyRepository _repo;

        public LegApiController(ITravelAgencyRepository repo)
        {
            _repo = repo;
        }

        // GET api/LegAPI
        public IEnumerable<Object> GetLegs(int id)
        {
            return _repo.GetLegsApi(id);


        }
    }
}