using System.Collections.Generic;
using System.Data;
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
            return Entities.Trips.OrderBy(t=>t.StartDate);
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

        public int GetNoGuestsOnTrip(int tripId)
        {
            var guestReg = Entities.GuestRegistrations.Where(r => r.Leg.TripId == tripId);     
            var guests = guestReg.Select(g => g.GuestId).Distinct();
            var numbeofGuests = 0;
            foreach (var guest in guests)
            {
                
                if (guestReg.Where(g => g.GuestId == guest).Distinct().Count() >= 2)
                    numbeofGuests++;

            }
            return numbeofGuests;
        }

        public IQueryable<Guest> GetGuests()
        {
            return Entities.Guests.OrderBy(g=>g.FirstName);
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

        public void AddGuest(Guest guest)
        {
            Entities.Guests.Add(guest);
            Entities.SaveChanges();
        }

        public Guest GetGuestById(int id)
        {
            return Entities.Guests.Find(id);
        }

        public IQueryable<object> GetLegsApi(int id)
        {
             var legs = from l in Entities.Legs 
                           where l.TripId==id
                           select new {
                               l.StartDate, 
                                     l.FinishDate,
                                     l.StartLocation,
                                     l.FinishLocation,
                                     l.TripId,
                                     l.Id,
                                     x=l.LegRegistrations.Count}; 
                return legs; 
        }

        public void Dispose()
        {
            Entities.Dispose();
        }

    }
}