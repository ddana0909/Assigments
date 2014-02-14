using System.Linq;
using TravelAgency.Models;

namespace TravelAgency.DAL
{
    public class TravelAgencyRepository:ITravelAgencyRepository
    {
        public TravelAgencyEntities Entities;

        public TravelAgencyRepository()
        {
            Entities= new TravelAgencyEntities();
        }
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