using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace TravelAgency.Models
{
    public class TravelAcencyInitializer:DropCreateDatabaseIfModelChanges<TravelAgencyEntities>
    {
        protected override void Seed(TravelAgencyEntities db)
        {

             var trips = new List<Trip>
            {
                new Trip{Name = "Discover Russia", StartDate = new DateTime(2014,08,15),FinishDate = new DateTime(2014,08,22),MinimumGuests = 4, Viable = true}
            };
            
            trips.ForEach(t=>db.Trips.Add(t));
            db.SaveChanges();

            var legs = new List<Leg>
            {
             new Leg {StartLocation = "Dublin", StartDate = new DateTime(2014, 08, 15), FinishLocation = "Moscow", FinishDate = new DateTime(2014, 08, 16),TripId = 1},
             new Leg {StartLocation = "Moscow", StartDate = new DateTime(2014, 08, 16), FinishLocation = "Suzdal", FinishDate = new DateTime(2014, 08, 17), TripId = 1},
             new Leg {StartLocation = "Suzdal", StartDate = new DateTime(2014, 08, 17), FinishLocation = "Novgorod", FinishDate = new DateTime(2014, 08, 18), TripId = 1},
             new Leg {StartLocation = "Novgorod",StartDate = new DateTime(2014, 08, 18),FinishLocation = "Bryansk",FinishDate = new DateTime(2014, 08, 19), TripId = 1},
             new Leg {StartLocation = "Bryansk", StartDate = new DateTime(2014, 08, 20),FinishLocation = "St. Petersburg", FinishDate = new DateTime(2014, 08, 21), TripId = 1},
             new Leg {StartLocation = "St. Petersburg", StartDate = new DateTime(2014, 08, 22),FinishLocation = "Dublin",FinishDate = new DateTime(2014, 08, 22), TripId = 1}
            };

            legs.ForEach(l=>db.Legs.Add(l));
            db.SaveChanges();
            
            var guests = new List<Guest>
            {
                new Guest {FirstName = "Carson"},
                new Guest {FirstName = "Arturo"},
                new Guest {FirstName = "Meredith"},
                new Guest {FirstName = "Yan"}
            };

            guests.ForEach(g=>db.Guests.Add(g));
            db.SaveChanges();

            var legReg = new List<LegRegistration>
            {
                new LegRegistration {LegId = 1, GuestId = 2},
                new LegRegistration {LegId = 1, GuestId = 3},
                new LegRegistration {LegId = 2, GuestId = 4},
                new LegRegistration {LegId = 2, GuestId = 1},
                new LegRegistration {LegId = 3, GuestId = 1},
                new LegRegistration {LegId = 4, GuestId = 2},
                new LegRegistration {LegId = 6, GuestId = 4},
                new LegRegistration {LegId = 6, GuestId = 3},
                new LegRegistration {LegId = 6, GuestId = 1}

            };

            legReg.ForEach(lr=>db.LegRegistrations.Add(lr));
            db.SaveChanges();

        }   
}
}


