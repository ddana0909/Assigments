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
                new Trip{Name = "Discover Russia", StartDate = new DateTime(2014,08,15),FinishDate = new DateTime(2014,08,22),MinimumGuests = 5, Viable = true, Complete = true, PicturePath = "~/Images/Russia.jpg"},
                new Trip{Name = "Discover Greece", StartDate = new DateTime(2014,07,01),FinishDate = new DateTime(2014,07,07),MinimumGuests = 10, Viable = false, Complete = true, PicturePath = "~/Images/Greece.jpg"}
            };
            
            trips.ForEach(t=>db.Trips.Add(t));
            db.SaveChanges();

            var legs = new List<Leg>
            {
             new Leg {StartLocation = "Dublin", StartDate = new DateTime(2014, 08, 15), FinishLocation = "Moscow", FinishDate = new DateTime(2014, 08, 16),TripId = 1},
             new Leg {StartLocation = "Moscow", StartDate = new DateTime(2014, 08, 16), FinishLocation = "Suzdal", FinishDate = new DateTime(2014, 08, 17), TripId = 1},
             new Leg {StartLocation = "Suzdal", StartDate = new DateTime(2014, 08, 17), FinishLocation = "Novgorod", FinishDate = new DateTime(2014, 08, 18), TripId = 1},
             new Leg {StartLocation = "Novgorod",StartDate = new DateTime(2014, 08, 18),FinishLocation = "Bryansk",FinishDate = new DateTime(2014, 08, 19), TripId = 1},
             new Leg {StartLocation = "Bryansk", StartDate = new DateTime(2014, 08, 20),FinishLocation = "St Petersburg", FinishDate = new DateTime(2014, 08, 21), TripId = 1},
             new Leg {StartLocation = "St Petersburg", StartDate = new DateTime(2014, 08, 22),FinishLocation = "Dublin",FinishDate = new DateTime(2014, 08, 22), TripId = 1},
            
             new Leg {StartLocation = "Dublin", StartDate = new DateTime(2014, 07, 01),FinishLocation = "Athens",FinishDate = new DateTime(2014, 07, 01), TripId = 2},
             new Leg {StartLocation = "Athens", StartDate = new DateTime(2014, 07, 02),FinishLocation = "Syros",FinishDate = new DateTime(2014, 07, 03), TripId = 2},
             new Leg {StartLocation = "Syros", StartDate = new DateTime(2014, 07, 03),FinishLocation = "Mykonos",FinishDate = new DateTime(2014, 07, 04), TripId = 2},
             new Leg {StartLocation = "Mykonos", StartDate = new DateTime(2014, 07, 04),FinishLocation = "Santorini",FinishDate = new DateTime(2014, 07, 05), TripId = 2},
             new Leg {StartLocation = "Santorini", StartDate = new DateTime(2014, 07, 05),FinishLocation = "Corfu",FinishDate = new DateTime(2014, 07, 06), TripId = 2},
             new Leg {StartLocation = "Corfu", StartDate = new DateTime(2014, 07, 06),FinishLocation = "Dublin",FinishDate = new DateTime(2014, 07, 07), TripId = 2}





            
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

            var legReg = new List<GuestRegistration>
            {
                new GuestRegistration {LegId = 1, GuestId = 2},
                new GuestRegistration {LegId = 1, GuestId = 3},
                new GuestRegistration {LegId = 2, GuestId = 4},
                new GuestRegistration {LegId = 2, GuestId = 1},
                new GuestRegistration {LegId = 3, GuestId = 1},
                new GuestRegistration {LegId = 4, GuestId = 2},
                new GuestRegistration {LegId = 6, GuestId = 4},
                new GuestRegistration {LegId = 6, GuestId = 3},
                new GuestRegistration {LegId = 6, GuestId = 1}

            };

            legReg.ForEach(lr=>db.GuestRegistrations.Add(lr));
            db.SaveChanges();

        }   
}
}


