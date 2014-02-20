using System;
using System.Linq;
using TravelAgency.Models;

namespace TravelAgency.DAL
{
    public interface ITravelAgencyRepository :IDisposable
    {
        IQueryable <Trip> GetAllTrips();
        Trip GetTrip(int? tripId);
        
        IQueryable <Leg> GetLegsForTrip(int tripId);
        void AddTrip(Trip trip);
        void AddLeg(Leg leg);
        void UpdateTrip(Trip trip);
    }

}
