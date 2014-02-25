using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using TravelAgency.Models;
using WebGrease.Css.Extensions;

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

        public Trip GetTrip(int? tripId)
        {
            return Entities.Trips.Find(tripId);
     
        }

        public Leg GetLeg(int legId)
        {
            return Entities.Legs.Find(legId);
        }

        public IEnumerable<Guest> GetGuestsOnLeg(int legId)
        {
            return Entities.Legs.Find(legId).LegRegistrations.Select(legR=>legR.Guest);

        }

        public IQueryable<Leg> GetLegsForTrip(int tripId)
        {
            return Entities.Legs.Where(t=>t.TripId == tripId).SortBy("StartDate");            
        }

        public IQueryable<Guest> GetGuests()
        {
            return Entities.Guests;
        }

        public IQueryable<GuestRegistration> GetGuestRegistrationsByLegAndGuest(int legId, int guestId)
        {
            return Entities.GuestRegistrations.Where(r => r.LegId == legId && r.GuestId == guestId);
        }

        public void AddTrip(Trip trip)
        {
            Entities.Trips.Add(trip);
            Entities.SaveChanges();
        }

        public void AddLeg(Leg leg)
        {
            Entities.Legs.Add(leg);
            Entities.SaveChanges();
        }

        public void UpdateTrip(Trip trip)
        {
            Entities.Trips.Attach(trip);
            Entities.Entry(trip).State= EntityState.Modified;
            Entities.SaveChanges();
        }

        public void AddGuestRegistration(GuestRegistration registration)
        {
            Entities.GuestRegistrations.Add(registration);
            Entities.SaveChanges();
        }

        public void Dispose()
        {
            Entities.Dispose();
        }
    }
}