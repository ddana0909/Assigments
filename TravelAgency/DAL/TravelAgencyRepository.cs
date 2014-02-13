using System.Linq;
using TravelAgency.Models;

namespace TravelAgency.DAL
{
    public class TravelAgencyRepository:ITravelAgencyRepository
    {
        public TravelAgencyEntities Entities;
         
        public IQueryable<Trip> GetAllTrips()
        {
            return Entities.Trips;
        }

        public void Dispose()
        {
            Entities.Dispose();
        }
    }
}