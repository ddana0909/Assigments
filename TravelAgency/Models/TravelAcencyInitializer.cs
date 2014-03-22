using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace TravelAgency.Models
{
    public class TravelAcencyInitializer:DropCreateDatabaseAlways<TravelAgencyEntities>
    {
        protected override void Seed(TravelAgencyEntities db)
        {

             var trips = new List<Trip>
            {
                new Trip{Name = "Discover Russia", StartDate = new DateTime(2014,08,15),FinishDate = new DateTime(2014,08,21),MinimumGuests = 5, Viable = true, Complete = true, PicturePath = "~/Images/Russia.jpg"},
                new Trip{Name = "Discover Greece", StartDate = new DateTime(2014,07,01),FinishDate = new DateTime(2014,07,07),MinimumGuests = 10, Viable = false, Complete = true, PicturePath = "~/Images/Greece.jpg"},
                new Trip{Name = "Cities of the Nile", StartDate = new DateTime(2014,06,27),FinishDate = new DateTime(2014,07,08),MinimumGuests = 3, Viable = true, Complete = false, PicturePath = "~/Images/Egypt.jpg"},
                new Trip{Name = "USA Tour", StartDate = new DateTime(2014,05,01),FinishDate = new DateTime(2014,05,10),MinimumGuests = 3, Viable = false, Complete = false, PicturePath = "~/Images/USA.jpg"},
                new Trip{Name = "Land of the Rising Sun",StartDate = new DateTime(2014,04,20),FinishDate = new DateTime(2014,04,29),MinimumGuests = 3, Viable = true, Complete = true, PicturePath = "~/Images/Japan.jpg"}
                
            };
            
            trips.ForEach(t=>db.Trips.Add(t));
            db.SaveChanges();

            var legs = new List<Leg>
            {
             new Leg {StartLocation = "Dublin", StartDate = new DateTime(2014, 08, 15), FinishLocation = "Moscow", FinishDate = new DateTime(2014, 08, 16),TripId = 1},
             new Leg {StartLocation = "Moscow", StartDate = new DateTime(2014, 08, 16), FinishLocation = "Suzdal", FinishDate = new DateTime(2014, 08, 17), TripId = 1},
             new Leg {StartLocation = "Suzdal", StartDate = new DateTime(2014, 08, 17), FinishLocation = "Novgorod", FinishDate = new DateTime(2014, 08, 18), TripId = 1},
             new Leg {StartLocation = "Novgorod",StartDate = new DateTime(2014, 08, 18),FinishLocation = "Bryansk",FinishDate = new DateTime(2014, 08, 19), TripId = 1},
             new Leg {StartLocation = "Bryansk", StartDate = new DateTime(2014, 08, 19),FinishLocation = "St Petersburg", FinishDate = new DateTime(2014, 08, 20), TripId = 1},
             new Leg {StartLocation = "St Petersburg", StartDate = new DateTime(2014, 08, 20),FinishLocation = "Dublin",FinishDate = new DateTime(2014, 08, 21), TripId = 1},
            
             new Leg {StartLocation = "Dublin", StartDate = new DateTime(2014, 07, 01),FinishLocation = "Athens",FinishDate = new DateTime(2014, 07, 02), TripId = 2},
             new Leg {StartLocation = "Athens", StartDate = new DateTime(2014, 07, 02),FinishLocation = "Syros",FinishDate = new DateTime(2014, 07, 03), TripId = 2},
             new Leg {StartLocation = "Syros", StartDate = new DateTime(2014, 07, 03),FinishLocation = "Mykonos",FinishDate = new DateTime(2014, 07, 04), TripId = 2},
             new Leg {StartLocation = "Mykonos", StartDate = new DateTime(2014, 07, 04),FinishLocation = "Santorini",FinishDate = new DateTime(2014, 07, 05), TripId = 2},
             new Leg {StartLocation = "Santorini", StartDate = new DateTime(2014, 07, 05),FinishLocation = "Corfu",FinishDate = new DateTime(2014, 07, 06), TripId = 2},
             new Leg {StartLocation = "Corfu", StartDate = new DateTime(2014, 07, 06),FinishLocation = "Dublin",FinishDate = new DateTime(2014, 07, 07), TripId = 2},

             new Leg {StartLocation = "Dublin", StartDate = new DateTime(2014, 06, 27),FinishLocation = "Alexandria",FinishDate = new DateTime(2014, 06, 28), TripId = 3},
             new Leg {StartLocation = "Alexandria", StartDate = new DateTime(2014, 06, 28),FinishLocation = "Cairo",FinishDate = new DateTime(2014, 06, 30), TripId = 3},
             new Leg {StartLocation = "Cairo", StartDate = new DateTime(2014, 06, 30),FinishLocation = "Beni Suef",FinishDate = new DateTime(2014, 07, 01), TripId = 3},
             new Leg {StartLocation = "Beni Suef", StartDate = new DateTime(2014, 07, 01),FinishLocation = "Asyut",FinishDate = new DateTime(2014, 07, 02), TripId = 3},
             new Leg {StartLocation = "Asyut", StartDate = new DateTime(2014, 07, 02),FinishLocation = "Luxor",FinishDate = new DateTime(2014, 07, 04), TripId = 3},
             new Leg {StartLocation = "Luxor", StartDate = new DateTime(2014, 07, 04),FinishLocation = "Al Madiq",FinishDate = new DateTime(2014, 07, 05), TripId = 3},
             new Leg {StartLocation = "Al Madiq", StartDate = new DateTime(2014, 07, 05),FinishLocation = "Aswan",FinishDate = new DateTime(2014, 07, 06), TripId = 3},

             new Leg {StartLocation = "Dublin", StartDate = new DateTime(2014, 05, 01),FinishLocation = "Los Angeles",FinishDate = new DateTime(2014, 05, 02), TripId = 4},
             new Leg {StartLocation = "Los Angeles", StartDate = new DateTime(2014, 05, 02),FinishLocation = "San Diego",FinishDate = new DateTime(2014, 05, 03), TripId = 4},
             new Leg {StartLocation = "San Diego", StartDate = new DateTime(2014, 05, 03),FinishLocation = "Grand Canyon",FinishDate = new DateTime(2014, 05, 04), TripId = 4},
             new Leg {StartLocation = "Grand Canyon", StartDate = new DateTime(2014, 05, 05),FinishLocation = "Las Vegas",FinishDate = new DateTime(2014, 05, 06), TripId = 4},
             new Leg {StartLocation = "Las Vegas", StartDate = new DateTime(2014, 05, 08),FinishLocation = "Sierra Nevada",FinishDate = new DateTime(2014, 05, 09), TripId = 4},
             new Leg {StartLocation = "Siera Nevada", StartDate = new DateTime(2014, 05, 09),FinishLocation = "San Francisco",FinishDate = new DateTime(2014, 05, 10), TripId = 4},
            
             new Leg {StartLocation = "Tokyo", StartDate = new DateTime(2014, 04, 20), FinishLocation = "Nikko",FinishDate = new DateTime(2014, 04, 23), TripId = 5},
             new Leg {StartLocation = "Nikko", StartDate = new DateTime(2014, 04, 23), FinishLocation = "Hakone",FinishDate = new DateTime(2014, 04, 24), TripId = 5},
             new Leg {StartLocation = "Hakone", StartDate = new DateTime(2014, 04, 24), FinishLocation = "Takayama",FinishDate = new DateTime(2014, 04, 26), TripId = 5},
             new Leg {StartLocation = "Takayama", StartDate = new DateTime(2014, 04, 26), FinishLocation = "Hiroshima",FinishDate = new DateTime(2014, 04, 27), TripId = 5},
             new Leg {StartLocation = "Hiroshima", StartDate = new DateTime(2014, 04, 27), FinishLocation = "Kyoto",FinishDate = new DateTime(2014, 04, 28), TripId = 5},
             new Leg {StartLocation = "Kyoto", StartDate = new DateTime(2014, 04, 28), FinishLocation = "Nagoya",FinishDate = new DateTime(2014, 04, 29), TripId = 5},
             
            };

            legs.ForEach(l=>db.Legs.Add(l));
            db.SaveChanges();

            var guests = new List<Guest>
            {
                new Guest {FirstName = "Carson"},
                new Guest {FirstName = "Arturo"},
                new Guest {FirstName = "Meredith"},
                new Guest {FirstName = "Yan"},
                new Guest {FirstName = "Jackson"},
                new Guest {FirstName = "John"},
                new Guest {FirstName = "Alice"},
                new Guest {FirstName = "Paula"},
                new Guest {FirstName = "Carla"},
                new Guest {FirstName = "Ana"},
                new Guest {FirstName = "Judith"},
                new Guest {FirstName = "Clair"},
                new Guest {FirstName = "Grace"},
                new Guest {FirstName = "Liana"},
                new Guest {FirstName = "Kate"},
                new Guest {FirstName = "Mary"},
                new Guest {FirstName = "Dererk"},
                new Guest {FirstName = "Neil"},
                new Guest {FirstName = "Michael"},
                new Guest {FirstName = "Paul"}
                
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
                new GuestRegistration {LegId = 6, GuestId = 1},
                
                new GuestRegistration {LegId = 13, GuestId = 8},
                new GuestRegistration {LegId = 15, GuestId = 8},
                new GuestRegistration {LegId = 16, GuestId = 8},
                new GuestRegistration {LegId = 16, GuestId = 9},
                new GuestRegistration {LegId = 17, GuestId = 1},
                new GuestRegistration {LegId = 18, GuestId = 1},
                new GuestRegistration {LegId = 19, GuestId = 9},
                new GuestRegistration {LegId = 19, GuestId = 5},
                new GuestRegistration {LegId = 19, GuestId = 2},
                new GuestRegistration {LegId = 15, GuestId = 1},

                new GuestRegistration {LegId = 26, GuestId = 10},
                new GuestRegistration {LegId = 26, GuestId = 5},
                new GuestRegistration {LegId = 27, GuestId = 4},
                new GuestRegistration {LegId = 27, GuestId = 10},
                new GuestRegistration {LegId = 28, GuestId = 4},
                new GuestRegistration {LegId = 28, GuestId = 5},
                new GuestRegistration {LegId = 29, GuestId = 12},
                new GuestRegistration {LegId = 30, GuestId = 3},
                new GuestRegistration {LegId = 29, GuestId = 18},
                new GuestRegistration {LegId = 30, GuestId = 2},

            };

            legReg.ForEach(lr=>db.GuestRegistrations.Add(lr));
            db.SaveChanges();

        }   
}
}


