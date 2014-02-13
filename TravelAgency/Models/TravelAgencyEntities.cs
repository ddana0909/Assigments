﻿using System.Data.Entity;

namespace TravelAgency.Models
{
    public class TravelAgencyEntities:DbContext
    {
        public DbSet<Leg> Legs { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Trip> Trips { get; set; }

    }
}