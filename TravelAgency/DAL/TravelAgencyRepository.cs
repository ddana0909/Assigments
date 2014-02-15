using System.Data.Common.CommandTrees;
using System.Linq;
using System.Web.UI.WebControls;
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

        public IQueryable<Leg> GetLegsForTrip(int tripId)
        {
            return Entities.Legs.Where(t=>t.TripId == tripId).SortBy("StartDate");            
        }

        public void AddTrip(Trip trip)
        {
            Entities.Trips.Add(trip);
            Entities.SaveChanges();
        }

        public void Dispose()
        {
            Entities.Dispose();
        }
    }
}