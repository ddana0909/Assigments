using System;
using System.Collections.Generic;

namespace TravelAgency.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int MinimumGuests { get; set; }
        public bool Viable { get; set; }

        public virtual ICollection<Leg> Legs { get; set; }
    }
}