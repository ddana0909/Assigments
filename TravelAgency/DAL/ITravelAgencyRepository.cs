using System;
using System.Collections.Generic;
using System.Linq;
using TravelAgency.Models;

namespace TravelAgency.DAL
{
    public interface ITravelAgencyRepository : IDisposable
    {
        IQueryable<Trip> GetAllTrips();
        Trip GetTrip(int? tripId);
        Leg GetLeg(int legId);
        IEnumerable<Guest> GetGuestsOnLeg(int legId);
        IQueryable<Leg> GetLegsForTrip(int tripId);

        int GetNoGuestsOnTrip(int tripId);
        IQueryable<Guest> GetGuests();
        IQueryable<GuestRegistration> GetGuestRegistrationsByLegAndGuest(int legId, int guestId);
        void AddTrip(Trip trip);
        void AddLeg(Leg leg);
        void UpdateTrip(Trip trip);
        void AddGuestRegistration(GuestRegistration registration);
        void AddGuest(Guest guest);

        Guest GetGuestById(int id);


        IQueryable<object> GetLegsApi(int id);

    }
}